using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed = 15;
	
	//private float isLeft = 0;
	//private float isUp = 0;
	public float boundary = 14.0f;
	void Move()	{
		float moveInputX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float moveInputY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		transform.position += new Vector3(moveInputX, moveInputY, 0);
	}
	
	void Update () {
		//float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		
		//transform.position += new Vector3(moveInput, 0, 0);
		Move ();

		if (transform.position.x <= -boundary || transform.position.x >= boundary)
		{
			float xPos = Mathf.Clamp(transform.position.x, -boundary, boundary); //Clamp between min -5 and max 5
			transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
		}
	}
	
	void OnCollisionExit(Collision collisionInfo ) {
		//Add X velocity..otherwise the ball would only go up&down
		Rigidbody rigid = collisionInfo.rigidbody;
		float xDistance = rigid.position.x - transform.position.x;
		rigid.velocity = new Vector3(rigid.velocity.x + xDistance/2, rigid.velocity.y, rigid.velocity.z);
	}
}
