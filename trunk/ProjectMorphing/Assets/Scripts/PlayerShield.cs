using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour 
{
	private bool isShieldUp = true;
	
	void Start() {
		gameObject.SetActive (isShieldUp);
	}
	
	void Update() {
		gameObject.SetActive (isShieldUp);
	}

	void OnTriggerEnter2D(Collision2D other)
	{
		if(isShieldUp)
		{
			isShieldUp = false;
		}
	}
}
