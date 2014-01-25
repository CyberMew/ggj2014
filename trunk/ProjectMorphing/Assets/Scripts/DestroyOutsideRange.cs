using UnityEngine;
using System.Collections;

public class DestroyOutsideRange : MonoBehaviour {
	// width is used as radius if it is a circle
	Vector2 size = new Vector2();
	
	// Use this for initialization
	void Start () {
		
		BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
		
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

		size *= 1.2f;
		InvokeRepeating ("CheckEdge", 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TestWithEdge(float edgeMin, float edgeMax, float minVal, float maxVal, int indexToTest)
	{
		if(minVal < edgeMin ||
		   maxVal > edgeMax)
		{
			Destroy(gameObject);
		}
	}
	
	void CheckEdge() {
		// check each extremes of box and if it exceeds, flip the required direction vector
		Vector2 position = transform.position;
		Vector2 min = position - size;
		Vector2 max = position + size;
		
		TestWithEdge(MySystem.edgeLeft, MySystem.edgeRight, min.x, max.x, 0);
		TestWithEdge(MySystem.edgeBottom, MySystem.edgeTop, min.y, max.y, 1);
	}
}
