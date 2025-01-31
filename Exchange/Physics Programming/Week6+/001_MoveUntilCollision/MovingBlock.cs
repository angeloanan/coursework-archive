using System;
using GXPEngine;
using GXPEngine.Core; // For Collision and Vector2

class MovingBlock : Sprite {
	Vec2 velocity;
	Vec2 acceleration;

	// settings:
	public static bool discrete = true;  // change with 'D'
	public static bool platformCollisions = false;	// change with 'P'

	public MovingBlock(	Vec2 pVelocity=new Vec2(), Vec2 pAcceleration=new Vec2(), float pRotation=0) : base("colors.png") {
		velocity=pVelocity;
		acceleration=pAcceleration;
		rotation=pRotation;
		SetOrigin(width/2, height/2);
	}

	void RandomReset() {
		velocity = new Vec2(Utils.Random(-15, 16), 0);
		rotation = Utils.Random(0,90);
		x=100 + Utils.Random(0,600);
		y=0;
	}

	GameObject[] GetPossibleCollisions() {
		if (discrete) {	// same way as MoveUntilCollision does it (discrete collision check):
			x += velocity.x;
			y += velocity.y;
			GameObject[] overlaps = GetCollisions();
			x -= velocity.x;
			y -= velocity.y;
			return overlaps;
		} else { // inefficient, but complete:
			return ((MyGame)game).staticBlocks;
		}
	}

	Collision CustomMoveUntilCollision(GameObject[] objectsToTest) {
		if (!platformCollisions) {
			// Standard way, using built-in MoveUntilCollision:

			// MoveUntilCollision does the "position += velocity" part of the Euler integration, 
			// the (discrete) collision detection,
			// the time & point of impact calculation, and 
			// the position resolve!:
			return MoveUntilCollision(velocity.x, velocity.y, objectsToTest);
		} else {
			// Here is the manual way, similar to how MoveUntilCollision does it (check the code),
			// but with a special condition (=normal has to point up):

			// Find the earliest collision *that satisfies our constraints*,
			// using the built-in TimeOfImpact method:
			float minTOI = 1;
			Collision col=null;

			foreach (GameObject other in objectsToTest) {
				Vector2 newNormal;
				float newTOI = TimeOfImpact(other, velocity.x, velocity.y, out newNormal);
				if (newTOI < minTOI && newNormal.y<=0) { // Note the custom normal direction condition!
					col = new Collision(this, other, newNormal, newTOI);
					minTOI = newTOI;
				}
			}

			// Move to point of impact, or move all the way if there was no collision (TOI=1):
			x += velocity.x * minTOI;
			y += velocity.y * minTOI;

			return col;
		}
	}

	void Update() {
		velocity += acceleration;

		GameObject[] possibleCollisions = GetPossibleCollisions();

		Collision col = CustomMoveUntilCollision(possibleCollisions);

		// Reflect velocity:
		if (col!=null) {
			// Translate the GXPEngine.Core.Vector2 to our own Vec2:
			velocity.Reflect(new Vec2(col.normal), 0.8f);
		}

		if (y>game.height || Input.GetKeyDown(Key.SPACE)) {
			RandomReset();
		}
	}
}
