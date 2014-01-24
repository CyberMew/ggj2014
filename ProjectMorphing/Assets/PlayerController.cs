using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed = 15;
	public float rotateSpeed = 15;
	public GameObject shot;
	public float fireRate;


	private float nextFire;
	private GameObject cam;


	void Start() {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update () {

		Move ();

		FaceCursor ();

		Shoot ();
	}
	
	void OnCollisionExit(Collision collisionInfo ) {
		//Add X velocity..otherwise the ball would only go up&down
		//Rigidbody rigid = collisionInfo.rigidbody;
		//float xDistance = rigid.position.x - transform.position.x;
		//rigid.velocity = new Vector3(rigid.velocity.x + xDistance/2, rigid.velocity.y, rigid.velocity.z);
	}

	void Move()	{
		float moveInputX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float moveInputY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

		transform.Translate (moveInputX,moveInputY,0,Space.World);
	}

	void Shoot() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
		
			Transform temp = transform;
			Instantiate(shot, temp.position, temp.rotation);

			//audio.Play ();
		}
	}

	void FaceCursor()
	{
		// Generate a plane that intersects the transform's position with an upwards normal.
		Plane playerPlane = new Plane(Vector3.forward, transform.position);
		
		// Generate a ray from the cursor position
		Ray ray = cam.camera.ScreenPointToRay(Input.mousePosition);
		
		// Determine the point where the cursor ray intersects the plane.
		// This will be the point that the object must look towards to be looking at the mouse.
		// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
		//   then find the point along that ray that meets that distance.  This will be the point
		//   to look at.
		
		float hitdist = 0;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			// Get the point along the ray that hits the calculated distance.
			Vector3 targetPoint = ray.GetPoint(hitdist);

			transform.LookAt(targetPoint);
			//transform.Rotate(0, Time.deltaTime, 0, Space.World);
			//
			//// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			//Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			//
			//// Smoothly rotate towards the target point.
			//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); // WITH SPEED
			////transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1); // WITHOUT SPEED!!!
		}
	}
}