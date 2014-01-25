using UnityEngine;
using System.Collections;

public class ClearScreenBuff : MonoBehaviour {

	public GameObject wipe;

	private GameObject expandingWipe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			expandingWipe = Instantiate (wipe, other.transform.position, Quaternion.identity) as GameObject;
		}
	}
}
