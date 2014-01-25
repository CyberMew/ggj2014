using UnityEngine;
using System.Collections;

public class BoxiPatrolScript : MonoBehaviour {
	
	// width is used as radius if it is a circle
	Vector2 size;
	BoxiWander boxiWander;
	
	// Use this for initialization
	void Start () {
		
		BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
		boxiWander = gameObject.GetComponent<BoxiWander>();
		
		// check which collider object is using, and use the appropriate collider type check
		if(boxCollider)
		{
			size = boxCollider.transform.TransformDirection(new Vector3(boxCollider.size.x, boxCollider.size.y, 0f));
		}
		else 
		{
			CircleCollider2D circleCollider = gameObject.GetComponent<CircleCollider2D>();
			
			if(circleCollider)
			{
				size.x = size.y = circleCollider.radius;
			}
		}
		
		InvokeRepeating ("CheckEdge", 0f, 0.1f);
	}
	
	void OnDestroy() {
		CancelInvoke();
	}
	
	void TestWithEdge(float edgeMin, float edgeMax, float minVal, float maxVal, ref Vector3 directionVec, int indexToTest)
	{
		if(minVal < edgeMin)
		{
			if(directionVec[indexToTest] < .0f)
			{
				directionVec[indexToTest] *= -1f;
				if(directionVec[indexToTest] > 0.9f)
				{
					int otherIndex = (indexToTest + 1) % 2;
					
					if(directionVec[otherIndex] > 0f)
					{
						directionVec[otherIndex] += 0.4f;
					}
					else
					{
						directionVec[otherIndex] -= 0.4f;
					}
					
					directionVec.Normalize();
				}
			}
		}
		else if(maxVal > edgeMax)
		{
			if(directionVec[indexToTest] > .0f)
			{
				directionVec[indexToTest] *= -1f;
				
				if(directionVec[indexToTest] < -0.9f)
				{
					int otherIndex = (indexToTest + 1) % 2;
					
					if(directionVec[otherIndex] > 0f)
					{
						directionVec[otherIndex] += 0.4f;
					}
					else
					{
						directionVec[otherIndex] -= 0.4f;
					}
					directionVec.Normalize();
				}
			}
		}
	}
	
	void CheckEdge() {
		
		if(!boxiWander)
		{
			return;
		}
		
		// check each extremes of box and if it exceeds, flip the required direction vector
		Vector2 position = transform.position;
		Vector2 min = position - size;
		Vector2 max = position + size;
		
		TestWithEdge(MySystem.edgeLeft, MySystem.edgeRight, min.x, max.x, ref boxiWander.directionVector, 0);
		TestWithEdge(MySystem.edgeBottom, MySystem.edgeTop, min.y, max.y, ref boxiWander.directionVector, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
