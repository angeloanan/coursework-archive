using GXPEngine;
using System.Collections.Generic;
using System;

class MyGame : Game {
	bool slow=false;
	bool gravity=true;
	VerletBody body;
	VerletDraw canvas;

	VerletPoint dragging=null;

	Vec2[] shape1 = new Vec2[] {
		new Vec2(-50,-50),
		new Vec2(50,-50),
		new Vec2(70,50),
		new Vec2(-70,50)
	};

	public MyGame() : base(800,600,false,false) {
		LoadScene(1);
	}

	void LoadScene(int sceneNumber) {
		body = new VerletBody();
		Vec2 center = new Vec2(width / 2, height / 2);

		switch (sceneNumber) {
			case 1:
				// 'Rigid' body:
				foreach (Vec2 point in shape1) {
					body.AddPoint(new VerletPoint(center + point));
				}
				for (int i = 0; i < shape1.Length - 1; i++) {
					for (int j = i + 1; j < shape1.Length; j++) {
						body.AddConstraint(i, j);
					}
				}
				break;
			case 2:
				// Rope with one fixed point:
				for (int i = 0; i < 6; i++) {
					body.AddPoint(new VerletPoint(width / 2, 100 + i * 50, i == 0));
					if (i > 0) {
						body.AddConstraint(i - 1, i, 0.5f, false);
					}
				}
				break;
			// TODO: get creative here!
			// case 3: ...
			default:
				// Curtain with two anchor points:
				int rows = 6;
				int cols = 10;
				for (int i = 0; i < rows; i++) {
					for (int j = 0; j < cols; j++) {
						body.AddPoint(new VerletPoint(150+j*50, 25 + i * 50, ((j == 0)||(j==cols-1))&&i==0));
						int index = i * cols + j;
						if (i > 0) {
							body.AddConstraint(index, index - cols, 0.2f, false);
						}
						if (j > 0) {
							body.AddConstraint(index, index-1, 0.2f, false);
						}
					}
				}
				break;
		}
		canvas = new VerletDraw(800, 600);
		AddChild(canvas);
	}

	void DestroyScene() {
		var children = GetChildren(); // gets a copy of the list, that's why this works:
		foreach (GameObject child in children) {
			child.Destroy();
		}
	}

	void Drag() {
		if (dragging == null) {
			if (Input.GetMouseButtonDown (0)) {
				Vec2 mouseDown = new Vec2 (Input.mouseX, Input.mouseY);
				foreach (VerletPoint p in body.point) {
					float dist = (p.position - mouseDown).Length ();
					if (dist < 10) {
						dragging = p;
						break;
					}
				}
			}
		} else {
			dragging.position = new Vec2 (Input.mouseX, Input.mouseY);
			if (Input.GetMouseButtonUp (0)) {
				dragging = null;
			}
		}
	}

	void Draw() {
		canvas.Clear (System.Drawing.Color.Transparent);
		canvas.DrawVerlet (body);
	}

	void DemoOptions() {
		if (Input.GetKeyDown (Key.S)) {
			slow ^= true;
			if (slow) {
				targetFps = 5;
			} else {
				targetFps = 60;
			}
		}
		if (Input.GetKeyDown (Key.G)) {
			gravity ^= true;		
		}
		if (Input.GetKeyDown(Key.ONE)) {
			DestroyScene();
			LoadScene(1);
		}
		if (Input.GetKeyDown(Key.TWO)) {
			DestroyScene();
			LoadScene(2);
		}
		if (Input.GetKeyDown(Key.THREE)) {
			DestroyScene();
			LoadScene(3);
		}
	}

	public void Update() {
		DemoOptions ();
		Drag ();

		if (gravity) {
			body.AddAcceleration (new Vec2 (0, 0.2f));
		}
		body.UpdateVerlet ();
		body.UpdateConstraints ();

		// simple collision resolve on boundaries:
		foreach (VerletPoint p in body.point) {
			if (p.position.y > 550) {
				p.y = 550; 
			}
			if (p.position.y < -550) {
				p.y = -550; 
			}

			if (p.x < 10) {
				p.x = 10; 
			}
			if (p.x > 790) {
				p.x = 790; 
			}
		}
		// ...and that's all there is to it!

		Draw ();
	}

	public static void Main (string[] args)
	{
		new MyGame ().Start ();
	}
}
