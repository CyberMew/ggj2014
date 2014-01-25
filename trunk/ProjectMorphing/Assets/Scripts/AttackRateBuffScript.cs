using UnityEngine;
using System.Collections;

public class AttackRateBuffScript : MonoBehaviour 
{
	public float attackSpeedMod = 0.5f;
	private AggressivePlayerAttack apa;
	public float hasteDuration = 10f;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Destroy(gameObject);

			apa = other.GetComponent<AggressivePlayerAttack>();
			
			if(apa)
			{
				apa.SetIsHasted(hasteDuration);
				apa.cooldownBuffModifier = attackSpeedMod;
			}
			else
			{
				Debug.Log("HasteBuff | PlayerComponents not found!");
			}
		}
	}
}
