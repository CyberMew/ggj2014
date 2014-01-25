using UnityEngine;
using System.Collections;

public class BoxiWander : MonoBehaviour {
	
	public Vector3 directionVector;
	public float speed = 0.9f;
	Transform myTransform;
	
	// Use this for initialization
	void Start () {
		// pick a random normalized vector
		float angleRadian = Random.Range(.0f, 2f * Mathf.PI - Mathf.Epsilon);
		directionVector = new Vector3(Mathf.Cos(angleRadian), Mathf.Sin(angleRadian), 0f);
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		// constantly move towards direction vector
		myTransform.Translate(directionVector * Time.deltaTime * speed);
	}
}
