using UnityEngine;
using System.Collections;

public class HasteBuff : MonoBehaviour 
{
	public float moveSpeedMod = 1.2f;
	public float attackSpeedMod = 0.5f;
	private AggressivePlayerMovement apm;
	private AggressivePlayerAttack apa;
	public float hasteDuration = 10f;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Destroy(gameObject);

			apm = other.GetComponent<AggressivePlayerMovement>();
			apa = other.GetComponent<AggressivePlayerAttack>();

			if(apm && apa)
			{
				apm.moveSpeedBuffModifier = moveSpeedMod;
				apm.SetIsHasted(hasteDuration);
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
