using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour {

	public GameObject shield;

	private GameObject player;
	private Vector3 dir;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");

		if(player)
		{
			dir = player.transform.position - transform.position;
			dir.Normalize ();
		}

		UpdateShield ();

		if(transform.childCount == 0)
		{
			Invoke ("ShieldUp", 2f);
		}
	}

	void ShieldUp() {
		CancelInvoke ();

		GameObject child = Instantiate (shield) as GameObject;
		child.transform.parent = this.transform;
		child.transform.localPosition = transform.position + dir;
	}

	void UpdateShield() {
		if(transform.childCount != 0)
			transform.GetChild (0).localPosition = transform.position + dir;
	}
}
