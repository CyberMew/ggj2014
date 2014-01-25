using UnityEngine;
using System.Collections;

class MySystem
{
	static public float sWIDTH = 1024f;
	static public float sHEIGHT = 768f;

	static public Vector2 ScreenToWorldV2(float x, float y)
	{
		Vector3 v = ScreenToWorldV3(x, y);
		return new Vector2(v.x, v.y);
	}

	static public Vector3 ScreenToWorldV3(float x, float y)
	{
		return Camera.main.ScreenToWorldPoint( new Vector3(x, y, 0f));
	}

}
