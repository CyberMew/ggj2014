using UnityEngine;
using System.Collections;

public class EnemySuicide : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");

		if(player)
		{
			Vector2 dir;
			dir.x = player.transform.position.x - transform.position.x;
			dir.y = player.transform.position.y - transform.position.y;
			dir.Normalize ();
			transform.Translate (dir * Time.deltaTime);
		}
	}

}
