using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour 
{
	public int totalShieldHealth = 3;
	private int currentShieldhealth;
	public float shieldRegenInSecond = 1f;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		currentShieldhealth = totalShieldHealth;
	}

	IEnumerator RegenShield()
	{
		yield return new WaitForSeconds(shieldRegenInSecond);

		if(currentShieldhealth != totalShieldHealth)
		{
			++currentShieldhealth;
			Debug.Log("fk dis shit");

			yield return new WaitForSeconds(0f);
		}

		yield return new WaitForSeconds(0f);
	}

	void DamageShield()
	{
		StopAllCoroutines();
		--currentShieldhealth;
		Debug.Log(currentShieldhealth);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(currentShieldhealth == 0)
		{
			return;
		}
		if(other.tag == "Player")
		{
			Destroy (gameObject);
			Destroy(other.gameObject);
		}
		else if(other.tag == "PlayerProjectile")
		{
			Destroy(other.gameObject);
			DamageShield();
		}
	}

	void Update()
	{
		StartCoroutine("RegenShield");
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer)
		{
			spriteRenderer.color = new Color(1f, 1f, 1f, (float)currentShieldhealth / totalShieldHealth);
		}
	}
}
