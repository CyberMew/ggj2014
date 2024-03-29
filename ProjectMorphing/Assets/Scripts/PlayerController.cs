﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed = 5f;
	public GameObject shot;
	public float angleModifier = 0.5f;
	public float angleInterpolatingInterval = 0.016f;

	public float fireRate;
	private float nextFire;
	public float targetAngle = 0f;

	void Start()
	{
		InvokeRepeating("InterpolateToTargetAngle", angleInterpolatingInterval, angleInterpolatingInterval);
	}

	void Update () {

		Move ();

		ComputeTargetAngle ();

		Shoot ();
	}
	
	void OnCollisionExit(Collision collisionInfo ) {

	}

	void Move()	{
		Vector2 moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		float len = moveVec.magnitude;
		if(len > 0f)
		{
			moveVec /= len;
			moveVec *= Time.deltaTime * moveSpeed;
			transform.Translate(moveVec.x, moveVec.y, 0f, Space.World);
		}
	}

	void Shoot() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
		
			Transform temp = transform;
			Instantiate(shot, temp.position, temp.rotation);

			//audio.Play ();
		}
	}

	void ComputeTargetAngle()
	{
		// Generate a ray from the cursor position
		Vector2 vecToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		targetAngle = Mathf.Rad2Deg * Mathf.Atan2(vecToMouse.y, vecToMouse.x);

		if(targetAngle < 0f)
		{
			targetAngle += 360f;
		}
	}

	void InterpolateToTargetAngle()
	{
		float oldAngle = transform.eulerAngles.z;
		float angleToChange = targetAngle - oldAngle;
		if(Mathf.Abs(angleToChange) > 180f)
		{
			angleToChange = angleToChange - 360f;
		}
		float newAngle = oldAngle + angleToChange * angleModifier;
		transform.eulerAngles = new Vector3(0f, 0f, newAngle);
	}
}