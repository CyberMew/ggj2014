using UnityEngine;
using System.Collections;

public class DestroyOutsideRange : MonoBehaviour {
	// width is used as radius if it is a circle
	Vector2 size;
	
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
		
		InvokeRepeating ("CheckEdge", 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckEdge()
	{

	}
}
