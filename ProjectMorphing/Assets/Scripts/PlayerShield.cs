using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour 
{
	public float invulnerableTime = 3f;

	private float curInvulTime = 0f;
	private bool isShieldUp = false;
	
	void Start() {
	}
	
	void Update() {
		curInvulTime -= Time.deltaTime;
		if(curInvulTime <= 0f && isShieldUp)
		{
			isShieldUp = false;
			// Disable all components except transform or this
			MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
			
			foreach(MonoBehaviour c in comps)
			{
				c.enabled = false;
			}
			
			this.enabled = true;
			Debug.Log("Shields Disabled");
		}
		//gameObject.SetActive (isShieldUp);
		//this.enabled = isShieldUp;
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, curInvulTime / invulnerableTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(isShieldUp)
		{
			if(other.gameObject.tag == "EnemyProjectile")
			{
				Destroy (other.gameObject);
			}
		}
	}

	public void ShieldsUp() {
		Debug.Log("Shields are up!");
		isShieldUp = true;
		curInvulTime = invulnerableTime;

		MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
		
		foreach(MonoBehaviour c in comps)
		{
			c.enabled = true;
		}
	}
}
