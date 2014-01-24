using UnityEngine;
using System.Collections;

public class BasicCollectorScript : MonoBehaviour 
{
	// this is the basic collect script.
	// all collectibles will have this script
	// which will call the body's add segment code

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//other.gameObject.AddSegment();
		}
	}
}
