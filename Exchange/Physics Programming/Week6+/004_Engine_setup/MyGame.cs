using GXPEngine;

public class MyGame : Game
{
	public MyGame() : base(800, 600, false,false)
	{
		AddChild(new Player(new Vec2(200, 200)));

		for (int i=0;i<10;i++) {
			AddChild(new SolidBlock(new Vec2(Utils.Random(0,width), Utils.Random(0,height))));
		}
		for (int i=0;i<10;i++) {
			AddChild(new Platform(new Vec2(Utils.Random(0,width), Utils.Random(0,height))));
		}
	}

	static void Main()
	{
		new MyGame().Start();
	}
}