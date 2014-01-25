using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBodyController : MonoBehaviour {
	public List<GameObject> bodyObjContainer = new List<GameObject>(); // for easy debugging
	public GameObject bodyObj = null;

	private int positionIndex = 0;
	private float colliderSize = 0f;
	List<Vector2> positionHistory = new List<Vector2>();

	// Use this for initialization
	void Start () {
		GameObject tempBody = Instantiate(bodyObj) as GameObject;

		CircleCollider2D circleCollider = gameObject.GetComponent<CircleCollider2D>();
		
		if(circleCollider)
		{
			colliderSize = circleCollider.radius;
			colliderSize = circleCollider.transform.TransformDirection(new Vector3(colliderSize, 0f, 0f)).magnitude;
		}
		
		colliderSize *= 2f;
		Destroy(tempBody);

		positionHistory.Add (transform.position);

		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();
		CreateBodyAtEnd();

	}

	void Update()
	{
		Vector2 lastPos = positionHistory[positionHistory.Count - 1];
		Vector2 currPos = transform.position;

		Vector2 travelVec = currPos - lastPos;

		if(travelVec.magnitude > 0.005f)
		{
			positionHistory.Add (currPos);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		UpdateBodies();
	}

	void UpdateBodies()
	{
		positionIndex = positionHistory.Count;

		if(positionIndex > 1)
		{
			--positionIndex;

			for(int i = 0; i < bodyObjContainer.Count; ++i)
			{
				PlayerBody body = bodyObjContainer[i].GetComponent<PlayerBody>();

				if(body)
				{
					body.SetTargetPos(GetNextNearestPosition(i));
				}
			}
		}
		else
		{
			Vector3 ownerPos = transform.position;
			for(int i = 0; i < bodyObjContainer.Count; ++i)
			{
				bodyObjContainer[i].transform.position = ownerPos;
			}
		}
	}

	Vector3 GetNextNearestPosition(int index)
	{
		Vector2 posOfFrontObj;

		switch(index)
		{
		case 0:
			posOfFrontObj = gameObject.transform.position;		
			break;
		default:
			posOfFrontObj = bodyObjContainer[index - 1].transform.position;
			break;
		}

		Vector2 prevPos = posOfFrontObj;
		Vector2 curPos = bodyObjContainer[index].transform.position;

		for(; positionIndex >= 0; --positionIndex)
		{
			curPos = positionHistory[positionIndex];

			Vector2 vecFromPlayerToNext = curPos - posOfFrontObj;

			float mag = vecFromPlayerToNext.magnitude;

			if(mag >= colliderSize)
			{
				break;
			}
			// else we need to coninue backing up the history to find a suitable position
			else
			{
				prevPos = curPos;
			}
		}

		return new Vector2(curPos.x, curPos.y);
	}

	public void CreateBodyAtEnd() {
		GameObject newBody = Instantiate(bodyObj, GetPosOfLastObj(), Quaternion.identity) as GameObject;
		bodyObjContainer.Add(newBody);
	}

	public void DestroyBodyAtEnd() {
		int size = bodyObjContainer.Count;
		
		if(size > 0)
		{
			--size;
			//Destroy and pop last object
			GameObject objToDestroy = bodyObjContainer[size];
			bodyObjContainer.Remove(objToDestroy);
			Destroy(objToDestroy);
		}
	}

	public void DestroySpecificBody(GameObject bodyObj)
	{
		GameObject obj = bodyObjContainer.Find (bodyObj.Equals);

		if(obj)
		{
			bodyObjContainer.Remove(obj);
			Destroy(obj);
		}
	}

	Vector2 GetPosOfLastObj()
	{
		int size = bodyObjContainer.Count;
		if(size > 0)
		{
			return bodyObjContainer[size - 1].transform.position;;
		}
		return gameObject.transform.position;
	}
}

