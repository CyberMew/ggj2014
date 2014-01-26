using UnityEngine;
using System.Collections;

public class ShieldBuff : MonoBehaviour {

	private PlayerShield ps;
	private GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			ps = other.gameObject.transform.GetComponentInChildren<PlayerShield>();
			if(ps)
			{
				ps.ShieldsUp ();
				Destroy (this.gameObject);
			}
		}
	}
}
