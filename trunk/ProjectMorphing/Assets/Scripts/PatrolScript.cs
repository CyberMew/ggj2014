using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour 
{
	// find a quarter of boundary
	private Vector2 halfVec;
	private Vector2 quarterVec;
	private Vector2 target1, target2;
	private Vector2 disp;
	private bool isFlipX = false;
	private bool isFlipY = false;
	public float speed  = 2.5f;
	private bool posX = false;
	private bool posY = false;

	void Start()
	{
		halfVec = .5f * MySystem.ScreenToWorldV2(MySystem.sWIDTH, MySystem.sHEIGHT);
		quarterVec = .5f * halfVec;
		target1 = transform.position;
		posX = (transform.position.x > 0f) ? true : false; 
		posY = (transform.position.y > 0f) ? true : false; 
		quarterVec.x *= (posX) ? -1f : 1f;
		quarterVec.y *= (posY) ? -1f : 1f;
		target2.x = target1.x + Random.insideUnitCircle.x * quarterVec.x;
		target2.y = target1.y + Random.insideUnitCircle.y * quarterVec.y;
		target2 += quarterVec;
		disp = (target2 - target1);
		disp.Normalize();
		disp *= speed * Time.fixedDeltaTime;
	}

	void FixedUpdate()
	{
		if(posX)
		{
			if(transform.position.x < target2.x)
			{
				isFlipX = true;
			}
			if(transform.position.x > target1.x)
			{
				isFlipX = false;
			}
		}
		else
		{
			if(transform.position.x > target2.x)
			{
				isFlipX = true;
			}
			if(transform.position.x < target1.x)
			{
				isFlipX = false;
			}
		}
		if(posY)
		{
			if(transform.position.y < target2.y)
			{
				isFlipY = true;
			}
			if(transform.position.y > target1.y)
			{
				isFlipY = false;
			}
		}
		else
		{
			if(transform.position.y > target2.y)
			{
				isFlipY = true;
			}
			if(transform.position.y < target1.y)
			{
				isFlipY = false;
			}
		}

		transform.Translate(isFlipX ? -disp.x : disp.x, isFlipY ? -disp.y : disp.y, 0f);
	}
}
