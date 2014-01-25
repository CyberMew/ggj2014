using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour 
{
	// find a quarter of boundary
	private Vector2 halfVec;
	private Vector2 quarterVec;
	private Vector2 target1, target2;
	private Vector2 disp;
	private bool isFlip = false;
	public float speed;

	void Start()
	{
		halfVec = .5f * MySystem.ScreenToWorldV2(MySystem.sWIDTH, MySystem.sHEIGHT);
		quarterVec = .5f * halfVec;
		target1 = transform.position;
		quarterVec.x *= (transform.position.x > 0f) ? -1f : 1f;
		quarterVec.y *= (transform.position.y > 0f) ? -1f : 1f;
		target2.x = target1.x + Random.insideUnitCircle.x * quarterVec.x;
		target2.y = target1.y + Random.insideUnitCircle.y * quarterVec.y;
		target2 += quarterVec;
		disp = (target2 - target1);
		disp.Normalize();
		disp *= speed * Time.fixedDeltaTime;
	}

	void FixedUpdate()
	{
		if(transform.position.x > target2.x)
			isFlip = true;
		if(transform.position.x < target1.x)
			isFlip = false;

		transform.Translate (isFlip ? -disp : disp);
	}
}
