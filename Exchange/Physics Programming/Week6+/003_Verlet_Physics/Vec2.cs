using System;

public struct Vec2 {
	public float x;
	public float y;

	public Vec2(float px, float py) {
		x = px;
		y = py;
	}

	public static Vec2 operator+(Vec2 left, Vec2 right) {
		return new Vec2 (left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator-(Vec2 left, Vec2 right) {
		return new Vec2 (left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator*(float scalar, Vec2 vec) {
		return new Vec2 (vec.x * scalar, vec.y * scalar);
	}

	public static Vec2 operator*(Vec2 vec, float scalar) {
		return new Vec2 (vec.x * scalar, vec.y * scalar);
	}



	public float Length() {
		return (float)Math.Sqrt (x * x + y * y);
	}

	public Vec2 Normalize() {
		float len = Length ();
		if (len > 0) {
			x = x / len;
			y = y / len;
		}
		return this;
	}



	public void SetXY(float px, float py) {
		x = px;
		y = py;
	}

	public override string ToString () {
		return "(" + x + "," + y + ")";
	}
}

