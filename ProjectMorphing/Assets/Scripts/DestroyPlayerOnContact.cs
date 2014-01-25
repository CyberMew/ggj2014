using UnityEngine;
using System.Collections;

// instagibs the player because players are noobz.

public class DestroyPlayerOnContact : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("fuck dis");
		if(other.tag == "Player")
		{
			Debug.Log("fuck dis again");
			Destroy(other.gameObject);
		}
	}
}
