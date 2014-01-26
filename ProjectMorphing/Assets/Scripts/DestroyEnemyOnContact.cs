using UnityEngine;
using System.Collections;

public class DestroyEnemyOnContact : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
