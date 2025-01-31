using System;

public struct Vec2 {
  public float x;
  public float y;

  // Constructor
  public Vec2(float x = 0, float y = 0) {
    this.x = x;
    this.y = y;
  }
  
  public void SetCoords(float x, float y) {
    this.x = x;
    this.y = y;
  }

  public Vec2 Abs() {
    return new Vec2(Math.Abs(x), Math.Abs(y));
  }

  /// <summary>
  ///	Calculates the current length of vector 
  /// </summary>
  /// <returns>Length of Vector</returns>
  public float Length() {
    return (float)Math.Sqrt(x * x + y * y);
  }

  /// <summary>
  /// Calculates the squared length / normal of the vector
  /// </summary>
  /// <returns></returns>
  public Vec2 Normalized() {
    var vectorLength = this.Length();

    return !(vectorLength > 0)
      ? new Vec2()
      : new Vec2(x / vectorLength, y / vectorLength);
  }


  /// <summary>
  /// Normalizes the current vector
  /// </summary>
  public void Normalize() {
    var normalizedVector = this.Normalized();

    this.x = normalizedVector.x;
    this.y = normalizedVector.y;
  }

  /// <summary>
  /// Simulate a vector rotation by the given angle
  /// </summary>
  /// <param name="angle">Angle in radians</param>
  /// <returns>Rotated vector</returns>
  public Vec2 Rotated(float angle) {
    var rotatedX = (float)(Math.Cos(angle) * this.x - Math.Sin(angle) * this.y);
    var rotatedY = (float)(Math.Sin(angle) * this.x + Math.Cos(angle) * this.y);

    return new Vec2(rotatedX, rotatedY);
  }

  public Vec2 RotatedDegrees(float angle) {
    return this.Rotated((float)(angle * Math.PI / 180));
  }

  public void Rotate(float angle) {
    var rotated = this.Rotated(angle);

    this.x = rotated.x;
    this.y = rotated.y;
  }

  public Vec2 UnitNormal() {
    var normalized = this.Normalized();

    return normalized.Rotated((float)Math.PI / 2);
  }

  /// <summary>
  /// Returns the unit tangent of the vector.
  /// </summary>
  /// <returns></returns>
  public Vec2 UnitTangent() {
    var normalized = this.Normalized();

    return normalized.Rotated((float)Math.PI);
  }
  
  public Vec2 Perpendicular() {
    return new Vec2(-this.y, this.x);
  }
  
  /// <summary>
  /// Projects this vector onto the given vector.
  /// </summary>
  /// <param name="other"></param>
  /// <returns>The length of the projected Vector</returns>
  public float ProjectLength(Vec2 other, float angle = 180) {
    other = other.Normalized();

    return (Dot(this, other) * (float) Math.Cos(angle));
  }
  
  /// <summary>
  /// Reflects this vector off the given normal. 
  /// </summary>
  /// <param name="normal"></param>
  /// <param name="elasticity"></param>
  /// <returns></returns>
  public Vec2 Reflect(Vec2 normal, float elasticity = 1) {
    return this - ((1 + elasticity) * (Dot(this, normal) * normal));
  }
  
  // Generic helper for operations

  public static Vec2 operator +(Vec2 left, Vec2 right) {
    return new Vec2(left.x + right.x, left.y + right.y);
  }

  public static Vec2 operator -(Vec2 left, Vec2 right) {
    return new Vec2(left.x - right.x, left.y - right.y);
  }

  public static Vec2 operator *(Vec2 v, float scalar) {
    return new Vec2(v.x * scalar, v.y * scalar);
  }

  public static Vec2 operator *(float scalar, Vec2 v) {
    return new Vec2(v.x * scalar, v.y * scalar);
  }

  public static Vec2 operator /(Vec2 v, float scalar) {
    return new Vec2(v.x / scalar, v.y / scalar);
  }

  public override string ToString() {
    return $"({x}, {y})";
  }
  
  /// <summary>
  /// Returns a vector with all elements set to `value`.
  /// </summary>
  public static Vec2 Splat(float value) {
    return new Vec2(value, value);
  }

  /// <summary>
  /// Computes the Dot Product of two vectors
  /// </summary>
  /// <param name="left"></param>
  /// <param name="right"></param>
  /// <returns></returns>
  public static float Dot(Vec2 left, Vec2 right) {
    return (left.x * right.x) + (left.y * right.y);
  }

  /// <summary>
  /// Also known as the Wedge Product, Perpendicular Dot Product, 2D Cross Product or the Determinant.
  /// </summary>
  /// <param name="left"></param>
  /// <param name="right"></param>
  /// <returns></returns>
  public static float Cross(Vec2 left, Vec2 right) {
    return left.x * right.y - left.y * right.x;
  }

  public static float AngleBetween(Vec2 left, Vec2 right) {
    return (float)Math.Acos(Dot(left, right) / (left.Length() * right.Length()));
  }
}