using UnityEngine;

public class Util
{
	public static double CalculateAccuracy(int txPower, double rssi)
	{
		if(rssi == 0)
		{
			return -1.0f;
		}

		double ratio = rssi * 1.0 / txPower;
		
		if(ratio < 1.0f)
		{
			return Mathf.Pow((float)ratio, 10);
		}
		else
		{
			double accuracy = (0.89976f) * Mathf.Pow((float)ratio, 7.7095f) + 0.111f;
			return accuracy;
		}
	}

	public static Vector2 CalculateCoordiates(Vector2 b1Pos, Vector2 b2Pos, Vector2 b3Pos, float b1Radius, float b2Radius, float b3Radius)
	{
		float va = ((b2Radius * b2Radius - b3Radius * b3Radius) - (b2Pos.x * b2Pos.x - b3Pos.x * b3Pos.x) - (b2Pos.y * b2Pos.y - b3Pos.y * b3Pos.y)) / 2.0f;
		float vb = ((b2Radius * b2Radius - b1Radius * b1Radius) - (b2Pos.x * b2Pos.x - b1Pos.x * b1Pos.x) - (b2Pos.y * b2Pos.y - b1Pos.y * b1Pos.y)) / 2.0f;

		float y = (vb * (b3Pos.x - b2Pos.x) - va * (b1Pos.x - b2Pos.x)) / ((b1Pos.y - b2Pos.y) * (b3Pos.x - b2Pos.x) - (b3Pos.y - b2Pos.y) * (b1Pos.x - b2Pos.x));
		float x = 0;

		if((b3Pos.x - b2Pos.x) != 0)
		{
			x = (va - y * (b3Pos.y - b2Pos.y)) / (b3Pos.x - b2Pos.x);
		}
		else
		{
			x = (vb - y * (b1Pos.y - b2Pos.y)) / (b1Pos.x - b2Pos.x);
		}
		return new Vector2(x, y);
	}
}
