using UnityEngine;
using System.Collections;

/*------------------------------------------------------------------------------------------------
 * 	Class for a generic spawning template.
 * 
 * 
 *-----------------------------------------------------------------------------------------------*/
class SpawnTemplate
{

	/*------------------------------------------------------------------------------------------------
 * 	Spawn an object.
 * 
 * 
 *-----------------------------------------------------------------------------------------------*/
	static public void SpawnObject(ref GameObject masterGameObject, float sqrMagFromPlayer)
	{
		//Vector3 worldDimension = MySystem.ScreenToWorldV3 (MySystem.sWIDTH, MySystem.sHEIGHT);
		//worldDimension /= 2f;

		Vector2 screenPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));

		//Vector2 screenPosition = new Vector2(Random.Range(-worldDimension.x,worldDimension.x), Random.Range(-worldDimension.y,worldDimension.y));
		Vector3 spawnPosition = new Vector3(screenPosition.x, screenPosition.y, 0f);
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		
		if (player == null)
		{
			Debug.LogWarning ("SpawnTemplate::SpawnObject - player can't be found!");
			return;
		}
		// randomly find a position to spawn the collectable
		// if collectable is colliding with anything, redo
		bool isLegalPosition = false;
		while (!isLegalPosition) 
		{
			Vector3 distanceVector = spawnPosition - player.transform.position;
			if(distanceVector.sqrMagnitude > sqrMagFromPlayer)
				isLegalPosition = true;
			else
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
		}
		
		// spawn the object
		MonoBehaviour.Instantiate (masterGameObject, spawnPosition, Quaternion.identity);
	}


	/*------------------------------------------------------------------------------------------------
 * 	Spawn an object.
 * 
 * 
 *-----------------------------------------------------------------------------------------------*/
	static public void SpawnObject(ref GameObject[] masterGameObjectArray, ref float[] spawnProbabilityArray, float sqrMagFromPlayer)
	{

		Vector2 screenPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
		Vector3 spawnPosition = new Vector3(screenPosition.x, screenPosition.y, 0f);
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		
		if (player == null)
		{
			Debug.LogWarning  ("SpawnTemplate::SpawnObject - player can't be found!");
			return;
		}
		
		// randomly find a position to spawn the collectable
		// if collectable is colliding with player, redo
		bool isLegalPosition = false;
		while (!isLegalPosition) 
		{
			Vector3 distanceVector = spawnPosition - player.transform.position;
			if(distanceVector.sqrMagnitude > sqrMagFromPlayer)
				isLegalPosition = true;
			else
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
		}
		
		// randomly pick the object and spawn it
		float randFloat = Random.Range (0.0f, 1.0f);
		int objIndex = 0;
		float testValue = 0.0f;
		
		for(; objIndex < spawnProbabilityArray.Length; ++objIndex)
		{
			testValue += spawnProbabilityArray[objIndex];
			
			if(testValue >= randFloat)
				break;
		}

		MonoBehaviour.Instantiate (masterGameObjectArray[objIndex], spawnPosition, Quaternion.identity);
	}
	
}
