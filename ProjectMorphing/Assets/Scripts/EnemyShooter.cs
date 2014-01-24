using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

	public GameObject enemyProjectile;
	public int splitCount;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Shoot () {
		float angle = 360 / splitCount * Mathf.Deg2Rad;
		
		for(int i = 0; i < splitCount; ++i)
		{
			// Sin and Cos outputs radians
			float x = Mathf.Cos (angle * i);
			float y = Mathf.Sin (angle * i);
			
			GameObject child = Instantiate (enemyProjectile) as GameObject;
			child.transform.localPosition = this.transform.localPosition;
			Vector3 pos = new Vector3(x, y, 0).normalized;
			
			child.transform.position += pos;
			
			child.rigidbody2D.AddForce ( (child.transform.position - transform.position) * 500f);
		}
	}

}
