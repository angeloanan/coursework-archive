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

	// NEW: translate from the GXPEngine.Core.Vector2 struct to our own struct:
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

	public static float Rad2Deg(float rad) {
		// TODO: insert the proper radians to degrees formula here!
		return rad;
	}

	public float Length() {
		return Mathf.Sqrt(x*x+y*y);
	}

	public float Dot(Vec2 other) {
		// TODO: insert the proper Dot formula here!
		return Length() * other.Length();
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

