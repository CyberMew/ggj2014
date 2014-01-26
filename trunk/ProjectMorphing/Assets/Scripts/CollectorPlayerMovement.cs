using UnityEngine;
using System.Collections;

public class CollectorPlayerMovement : MonoBehaviour {
	
	public float baseMoveSpeed = 1f;
	public float angleChangeSpeed = 25f;
	public float maxTurnAngle = 5f;
	
	private Vector2 dirVec = new Vector2();
	private float size = 1f;
	
	// Use this for initialization
	void Start()
	{
		CircleCollider2D circleCollider = gameObject.GetComponent<CircleCollider2D>();
		
		if(circleCollider)
		{
			size = circleCollider.radius;
		}
		size *= 1.5f;
		
		UpdateMinMaxAngle();
	}
	
	void Update () 
	{
		Move ();
		UpdateRotation();
	}
	
	void Move()	{
		float moveSpeed = Time.deltaTime * baseMoveSpeed;
		
		Vector3 moveVec = Vector3.Cross(transform.up, transform.forward);
		
		moveVec *= moveSpeed;
		
		UpdateMinMaxAngle();
		
		Vector2 position = transform.position;
		
		// move left
		if(moveVec.x < 0f)
		{
			if(position.x - size <= MySystem.edgeLeft)
			{
				Destroy(gameObject);
				return;
			}
		}
		// move right
		else
		{
			if(position.x + size>= MySystem.edgeRight)
			{
				Destroy(gameObject);
				return;
			}				
		}
		
		// move down
		if(moveVec.y < 0f)
		{
			if(position.y - size <= MySystem.edgeBottom)
			{
				Destroy(gameObject);
				return;
			}				
		}
		// move up
		else
		{
			if(position.y + size >= MySystem.edgeTop)
			{
				Destroy(gameObject);
				return;
			}					
		}
		
		position.x += moveVec.x;
		position.y += moveVec.y;
		
		transform.position = new Vector3(position.x, position.y, 0f);
	}
	
	void UpdateMinMaxAngle()
	{
		dirVec = Vector3.Cross(transform.up, transform.forward);
	}
	
	Vector2 MatrixMultVec(float ux, float uy, float vx, float vy, Vector2 vec)
	{
		Vector2 res = new Vector2(ux * vec.x + vx * vec.y, uy * vec.x + vy * vec.y);
		return res;
	}
	
	void UpdateRotation()
	{
		float turnSpeed = Input.GetAxisRaw("Horizontal");
		turnSpeed *= -angleChangeSpeed * Time.deltaTime;
		float newAngle = Mathf.Deg2Rad * (transform.eulerAngles.z + turnSpeed);
		
		// compute deg of new angle in local space
		Vector2 newVec = new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle));
		Vector2 localNewVec = MatrixMultVec(dirVec.x, -dirVec.y, dirVec.y, dirVec.x, newVec);
		float degNewAngle = Mathf.Rad2Deg * Mathf.Atan2(localNewVec.y, localNewVec.x);
		
		// clamp it in range first (working in local space makes it much easier)
		float radLocalFinal = degNewAngle;
		if(degNewAngle < 0f)
		{
			if(degNewAngle < -maxTurnAngle)
			{
				radLocalFinal = -maxTurnAngle;
			}
		}
		else
		{
			if(degNewAngle > maxTurnAngle)
			{
				radLocalFinal = maxTurnAngle;
			}
		}
		
		radLocalFinal *= Mathf.Deg2Rad;
		
		// change it back to a vec then convert back to world space vec then convert back to angle in deg
		Vector2 localFinalVec = new Vector2(Mathf.Cos(radLocalFinal), Mathf.Sin(radLocalFinal));
		Vector2 worldFinalVec = MatrixMultVec(dirVec.x, dirVec.y, -dirVec.y, dirVec.x, localFinalVec);
		
		transform.eulerAngles = new Vector3(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(worldFinalVec.y, worldFinalVec.x));
	}
}
