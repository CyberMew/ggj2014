using UnityEngine;
using System.Collections;

class MySystem
{
	static public float sWIDTH = 1024f;
	static public float sHEIGHT = 768f;

	static Vector3 ScreenToWorld(float x, float y)
	{
		return Camera.main.ScreenToWorldPoint (new Vector3 (x, y, 0f));
	}

}
