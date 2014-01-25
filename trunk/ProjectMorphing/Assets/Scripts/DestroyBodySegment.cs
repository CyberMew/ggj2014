using UnityEngine;
using System.Collections;

public class DestroyBodySegment : MonoBehaviour
{
	private PlayerBodyController pbc;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Destroy(gameObject);
			pbc = other.GetComponent<PlayerBodyController>();
			if(pbc)
			{
				pbc.DestroyBodyAtEnd();
			}
			else
			{
				Debug.Log ("DestroyBodySegment | Collided with head: Cannot find body controller!");
			}
		}
		else if(other.tag =="PlayerBody")
		{
			Destroy(gameObject);
			pbc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBodyController>();
			if(pbc)
			{
				pbc.DestroySpecificBody(other.gameObject);
			}
			else
			{
				Debug.Log ("DestroyBodySegment | Collided with body: Cannot find body controller!");
			}
		}
	}
}
