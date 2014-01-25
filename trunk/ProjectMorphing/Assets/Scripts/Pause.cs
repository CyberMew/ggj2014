using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private float prevTimeScale;
	// Use this for initialization
	void Start () {

		prevTimeScale = Time.timeScale;
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destroy()
	{
		Time.timeScale = 1f;
	}

	void OnGUI()
	{

	}
}
