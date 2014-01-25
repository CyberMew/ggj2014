using UnityEngine;
using System.Collections;

public class FlyForward : MonoBehaviour {
	public Vector3 shootingVector = new Vector3(1f, 0f, 0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(shootingVector);
	}
}
