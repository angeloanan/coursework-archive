using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}


	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}

    public double Length()
    {
        return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));
    }

    public void Normalize() {
        double vectorLength = this.Length();
        this.x = (float)(x / vectorLength);
        this.y = (float)(y / vectorLength);
    }

    public void SetLength(float length)
    {
        this.Normalize();
        this.x = this.x * length;
        this.y = this.y * length;
    }
}

