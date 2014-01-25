using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AggressiveMelee : MonoBehaviour {
	List<GameObject> collidingEnemyGroup = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "enemy")
		{
			collidingEnemyGroup.Add(coll.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "enemy")
		{
			// if obj failed to be removed, flag error!
			if(!collidingEnemyGroup.Remove(coll.gameObject))
			{
				Debug.LogError("colliding enemy count for aggressive melee component reaches 0");
			}
		}		
	}

	public bool Attack() 
	{
		bool result = false;
		foreach(GameObject obj in collidingEnemyGroup)
		{
			result = true;
			Destroy(obj);
		}
		return result;
	}
}
