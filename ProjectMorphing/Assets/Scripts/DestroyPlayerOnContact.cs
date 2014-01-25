using UnityEngine;
using System.Collections;

// instagibs the player because players are noobz.

public class DestroyPlayerOnContact : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Destroy(other.gameObject);
		}
	}
}
