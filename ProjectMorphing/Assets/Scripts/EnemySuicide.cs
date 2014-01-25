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

		Debug.Log(player);
		if(player)
		{
			Vector3 dir = player.transform.position - transform.position;
			dir.Normalize ();
			transform.Translate (dir * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision collision) 
	{
		//EnemyHealth script = GetComponent<EnemyHealth>();
		//
		//if(collision.gameObject.CompareTag("WallV") || collision.gameObject.CompareTag ("WallH") )
		//{
		//	gameObject.SendMessage("Hit", script.GetHP());
		//	var particle = Instantiate(hitParticle, transform.position, transform.rotation);
		//	Destroy (particle, 3);
		//}
		//else if(player == collision.gameObject)
		//{			
		//	gameObject.SendMessage("Hit", script.GetHP());
		//	player.SendMessage ("Hit", damage);
		//	var particle = Instantiate(hitParticle, transform.position, transform.rotation);
		//	Destroy (particle, 3);
		//}
	}
}
