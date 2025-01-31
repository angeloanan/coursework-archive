using System;
using GXPEngine;	// For Mathf

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}

	// NEW: translate from the GXPEngine.Core struct to our own struct:
	public Vec2 (GXPEngine.Core.Vector2 vec) {
		x=vec.x;
		y=vec.y;
	}

	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}

	public void SetXY(float pX, float pY) 
	{
		x = pX;
		y = pY;
	}

	public float Length() {
		return Mathf.Sqrt (x * x + y * y);
	}

	public void Normalize() {
		float len = Length ();
		if (len > 0) {
			x /= len;
			y /= len;
		}
	}

	public Vec2 Normalized() {
		Vec2 result = new Vec2 (x, y);
		result.Normalize ();
		return result;
	}

	// TODO: insert your reflect method here
	public void Reflect(Vec2 unitNormal, float COR=1) {
		// ...because this is not proper reflection:
		this *= -COR;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right) {
		return new Vec2 (left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right) {
		return new Vec2 (left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 v, float scalar) {
		return new Vec2 (v.x * scalar, v.y * scalar);
	}

	public static Vec2 operator *(float scalar, Vec2 v) {
		return new Vec2 (v.x * scalar, v.y * scalar);
	}

	public static Vec2 operator /(Vec2 v, float scalar) {
		return new Vec2 (v.x / scalar, v.y / scalar);
	}
}