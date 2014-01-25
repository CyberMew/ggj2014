using UnityEngine;
using System.Collections;

public class AggressivePlayerMovement : MonoBehaviour {
	
	public float baseMoveSpeed = 5f;
	public float moveSpeedBuffModifier = 1f;
	public float angleModifier = 0.5f;
	public float angleInterpolatingInterval = 0.016f;
	public float targetAngle = 0f;
	private float size = 1f;
	private bool isHasted = false;
	private float hasteDuration = 10f;

	public void SetIsHasted(float duration)
	{
		StopAllCoroutines();
		hasteDuration = duration;
		isHasted = true;
	}

	IEnumerator RemoveHaste()
	{
		yield return new WaitForSeconds(hasteDuration);
		moveSpeedBuffModifier = 1f;
	}

	// Use this for initialization
	void Start()
	{
		CircleCollider2D circleCollider = gameObject.GetComponent<CircleCollider2D>();
		
		if(circleCollider)
		{
			size = circleCollider.radius;
		}
		size *= 1.2f;

		InvokeRepeating("InterpolateToTargetAngle", angleInterpolatingInterval, angleInterpolatingInterval);
	}

	void Update () 
	{
		Move ();
		ComputeTargetAngle ();
		if(isHasted)
		{
			StartCoroutine("RemoveHaste");
		}
	}

	void Move()	{
		Vector2 moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		float len = moveVec.magnitude;
		if(len > 0f)
		{
			moveVec /= len;
			moveVec *= Time.deltaTime * baseMoveSpeed * moveSpeedBuffModifier;

			Vector2 position = transform.position;

			// move left
			if(moveVec.x < 0f)
			{
				if(position.x - size <= MySystem.edgeLeft)
				{
					moveVec.x = 0f;
				}
			}
			// move right
			else
			{
				if(position.x + size>= MySystem.edgeRight)
				{
					moveVec.x = 0f;
				}				
			}

			// move down
			if(moveVec.y < 0f)
			{
				if(position.y - size <= MySystem.edgeBottom)
				{
					moveVec.y = 0f;
				}				
			}
			// move up
			else
			{
				if(position.y + size >= MySystem.edgeTop)
				{
					moveVec.y = 0f;
				}					
			}

			transform.Translate(moveVec.x, moveVec.y, 0f, Space.World);
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