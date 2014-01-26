using UnityEngine;
using System.Collections;

// instagibs the player because players are noobz.

public class DestroyPlayerOnContact : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			StopAllCoroutines ();
			Destroy(other.gameObject);
			GameObject obj = GameObject.FindGameObjectWithTag ("WinLoseManager");
			if(obj)
			{
				WinLoseManagerScript wls = obj.GetComponent<WinLoseManagerScript>();
				if(wls)
				{
					wls.LoseGame ();
				}
			}
			Destroy(gameObject);
		}
	}
}
