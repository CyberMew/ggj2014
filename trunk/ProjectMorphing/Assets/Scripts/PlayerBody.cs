using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour {

	private Vector3 targetPos = new Vector3();

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.position;
		Vector3 tempVec = targetPos - oldPos;
		tempVec *= 0.6f;

		transform.Translate(tempVec); 
	}

	public void SetTargetPos(Vector3 newTargetPos)
	{
		Vector3 oldPos = transform.position;
		Vector3 tempVec = newTargetPos - oldPos;

		float len = tempVec.magnitude;

		if(len > 1.2f)
		{
			transform.position = newTargetPos;
		}

		targetPos = newTargetPos;
	}
}
