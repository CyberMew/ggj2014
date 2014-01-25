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
			//obj.SetActive (true);
			//ps = obj.GetComponent<PlayerShield>();
			//ps = other.gameObject.transform.GetChild(1).GetComponent<PlayerShield>();//.enabled = true;
			if(ps)
			{
				Debug.Log("ohyeah");
				ps.ShieldsUp ();
			}
		}
	}
}
