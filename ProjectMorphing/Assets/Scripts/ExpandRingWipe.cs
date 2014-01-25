using UnityEngine;
using System.Collections;

public class ExpandRingWipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale *= 1.2f;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag != "Player")
			Destroy (other.gameObject);
	}
}
