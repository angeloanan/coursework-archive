using System;
using System.Collections.Generic;
using GXPEngine;

public class MyGame : Game
{
	public Sprite[] staticBlocks;

	public MyGame() : base(800, 600, false, false)
	{
		SpawnBlocks();
		SpawnRandomMovers();
	}

	void SpawnRandomMovers(int numMovers=1, float moverScale=1) {
		for (int i = 0; i<numMovers; i++) {
			var mover = new MovingRotatingBlock(new Vec2(Utils.Random(-15, 16), 0), new Vec2(0, 0.1f), Utils.Random(0, 90));
			mover.x=100 + Utils.Random(0, 600);
			mover.scaleX *= moverScale;
			mover.scaleY *= moverScale;
			AddChild(mover);
		}
	}

	void SpawnBlocks(int number=10, int seed=0, float staticBlockScaleX=1, float staticBlockScaleY=1) {
		List<Sprite> blocks = new List<Sprite>();

		Random rnd = new Random(seed); // fixed seed
		for (int i=0;i<number;i++) {
			// Create a sprite with random position, rotation and scale:
			Sprite staticBlock = new Sprite("colors.png");
			staticBlock.SetOrigin(staticBlock.width/2, staticBlock.height/2);
			staticBlock.rotation=rnd.Next(0, 180);
			staticBlock.x = rnd.Next(0, width);
			staticBlock.y = rnd.Next(0, height);
			staticBlock.scaleX=((float)rnd.NextDouble() * 2 + 0.5f) * staticBlockScaleX;
			staticBlock.scaleY=((float)rnd.NextDouble() * 2 + 0.5f) * staticBlockScaleY;
			AddChild(staticBlock);
			blocks.Add(staticBlock);
		}

		Sprite leftWall = new Sprite("colors.png");
		leftWall.scaleY=2 * height/leftWall.height;
		AddChild(leftWall);
		blocks.Add(leftWall);

		Sprite rightWall = new Sprite("colors.png");
		rightWall.scaleY=2 * height/rightWall.height;
		rightWall.x=width-rightWall.width;
		AddChild(rightWall);
		blocks.Add(rightWall);

		staticBlocks=blocks.ToArray();
	}

	void DestroyScene() {
		var children = GetChildren(); // gets a copy of the list, that's why this loop works:
		foreach (GameObject child in children) {
			child.Destroy();
		}
	}

	void Update()
	{
	}

	static void Main()
	{
		new MyGame().Start();
	}
}