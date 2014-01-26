using UnityEngine;
using System.Collections;

public class EnemySuicide : MonoBehaviour {

	private GameObject player;
	private Vector2 targetDirectionVec;
	private float angleRad = 0f;
	
	// Use this for initialization
	void Start () {
		targetDirectionVec = Vector3.Cross (transform.up, transform.forward);
		angleRad = Mathf.Atan2(targetDirectionVec.y, targetDirectionVec.x);		
	}

	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");

		if(player)
		{

			targetDirectionVec.x = player.transform.position.x - transform.position.x;
			targetDirectionVec.y = player.transform.position.y - transform.position.y;

			float len = targetDirectionVec.magnitude;

			if(len > 0.001f)
			{
				float deg = Mathf.Rad2Deg * Mathf.Atan2(targetDirectionVec.y, targetDirectionVec.x);	
				transform.eulerAngles = new Vector3(0f, 0f, deg);

				targetDirectionVec /= len;
				transform.Translate (targetDirectionVec * Time.deltaTime, Space.World);
			}
		}
	}

}
