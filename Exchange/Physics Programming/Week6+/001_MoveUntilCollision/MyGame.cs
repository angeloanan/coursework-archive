using System;
using System.Drawing;
using System.Collections.Generic;
using GXPEngine;

public class MyGame : Game
{
	public Sprite[] staticBlocks;

	EasyDraw display;
	int displayUpdateCounter = 0;

	public MyGame() : base(800, 600, false, false)
	{
		SpawnBlocks();
		SpawnRandomMovers();

		display = new EasyDraw(100, 20);
		display.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(display);
	}

	void SpawnRandomMovers(int numMovers=1, float moverScale=1) {
		for (int i = 0; i<numMovers; i++) {
			var mover = new MovingBlock(new Vec2(Utils.Random(-15, 16), 0), new Vec2(0, 0.2f), Utils.Random(0, 90));
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
		display.Remove(); // prevent destruction - move out of the hierarchy
		var children = GetChildren(); // Gets a copy of the list, that's why this loop works:
		foreach (GameObject child in children) {
			child.Destroy();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(Key.ONE)) { // basic scene, one mover
			DestroyScene();
			SpawnBlocks();
			SpawnRandomMovers();
			AddChild(display);
		} else if (Input.GetKeyDown(Key.TWO)) { // different basic scene, one mover
			DestroyScene();
			SpawnBlocks(10,1);
			SpawnRandomMovers();
			AddChild(display);
		} else if (Input.GetKeyDown(Key.THREE)) { // tunneling: everything tiny
			DestroyScene();
			SpawnBlocks(50, 0, 2, 0.02f);
			SpawnRandomMovers(1,0.05f);
			AddChild(display);
		} else if (Input.GetKeyDown(Key.FOUR)) { // stress test
			DestroyScene();
			SpawnBlocks(100,0,1,0.02f);
			SpawnRandomMovers(100,0.05f);
			AddChild(display);
		} 

		if (Input.GetKeyDown(Key.D)) {
			MovingBlock.discrete ^= true;
			Console.WriteLine("Discrete collision detection: {0}",MovingBlock.discrete);
		}
		if (Input.GetKeyDown(Key.P)) {
			MovingBlock.platformCollisions ^= true;
			Console.WriteLine("Custom platform collision detection: {0}",MovingBlock.platformCollisions);
		}

		displayUpdateCounter--;
		if (displayUpdateCounter < 0) {
			display.Clear(Color.FromArgb(128, 0, 0, 0));
			display.Text("FPS: "+currentFps, 0, 0);
			displayUpdateCounter+=20;
		}
	}

	static void Main()
	{
		new MyGame().Start();
	}
}