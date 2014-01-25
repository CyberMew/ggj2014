using UnityEngine;
using System.Collections;

class MySystem : MonoBehaviour
{
	static public float sWIDTH = 1024f;
	static public float sHEIGHT = 768f;

	public static float edgeLeft;
	public static float edgeRight;
	public static float edgeTop;
	public static float edgeBottom;
	public static bool isDebugMode = true;
	
	// Use this for initialization
	void Start () {
		Camera mainCamera = Camera.main;
		float nearClipPlane = mainCamera.nearClipPlane;
		Vector3 min = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, nearClipPlane));
		Vector3 max = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, nearClipPlane));
		edgeLeft = min.x;
		edgeRight = max.x;
		edgeTop = max.y;
		edgeBottom = min.y;
	}

	static public Vector2 ScreenToWorldV2(float x, float y)
	{
		Vector3 v = ScreenToWorldV3(x, y);
		return new Vector2(v.x, v.y);
	}

	static public Vector3 ScreenToWorldV3(float x, float y)
	{
		return Camera.main.ScreenToWorldPoint( new Vector3(x, y, 0f));
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			isDebugMode = !isDebugMode;
		}
	}
}
