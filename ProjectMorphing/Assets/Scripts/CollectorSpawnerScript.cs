using UnityEngine;
using System.Collections;

public class CollectorSpawnerScript : MonoBehaviour {
	
	public GameObject[] collectibleArray;
	public float[] collectibleSpawnChanceArray;

	public GameObject[] obstacleArray;
	public float[] obstacleSpawnChanceArray;

	public float sqDistFromPlayer;
	public float sqDistFromObstacle;
	public float sqDistFromCollectible;

	// Use this for initialization
	void Start () {

		float totalPercentage = 0.0f;
		for (int i = 0; i < collectibleSpawnChanceArray.Length; ++i)
			totalPercentage += collectibleSpawnChanceArray [i];

		if(totalPercentage > 1.0f)
			Debug.Log ("CollectorSpawnScript::Start() - total combined percentage for collectible spawn chance exceeds 1!");
		else if(totalPercentage < 1.0f)
			Debug.Log ("CollectorSpawnScript::Start() - total combined percentage for collectible spawn chance is less than 1!");

		float totalObstaclePercentage = 0.0f;
		for (int i = 0; i < obstacleSpawnChanceArray.Length; ++i)
			totalObstaclePercentage += obstacleSpawnChanceArray [i];
		
		if(totalObstaclePercentage > 1.0f)
			Debug.Log ("CollectorSpawnScript::Start() - total combined percentage for obstacle spawn chance exceeds 1!");
		else if(totalObstaclePercentage < 1.0f)
			Debug.Log ("CollectorSpawnScript::Start() - total combined percentage for obstacle spawn chance is less than 1!");

	}

	// create obstacle
	// create collectable

	// obstacles remove themselves periodically
	// calls for new obstacles to be created after delay X
	// change obstacle count every Y seconds
	public void SpawnObstacle()
	{
		Vector2 screenPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
		Vector3 spawnPosition = new Vector3(screenPosition.x, screenPosition.y, 0f);
		
		// retrieve for checks
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		GameObject[] listOfCollectibles = GameObject.FindGameObjectsWithTag("Powerup");
		
		if (player == null)
			Debug.LogError  ("CollectorSpawnerScript::SpawnObstacle - player can't be found!");
		
		// randomly find a position to spawn the collectable
		// if collectable is colliding with player, redo
		bool check = false;
		
		while (true) 
		{
			Vector3 distanceVector = spawnPosition - player.transform.position;
			// first check against player
			if(distanceVector.sqrMagnitude < sqDistFromPlayer)
			{
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
				continue;
			}
			
			// second check against all obstacles
			check = true;
			for(int i = 0; i < listOfCollectibles.Length; ++i)
			{
				distanceVector = spawnPosition - listOfCollectibles[i].transform.position;
				if(distanceVector.sqrMagnitude < sqDistFromCollectible){
					check = false;
					break;
				}
			}
			
			if(!check){
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
				continue;
			}
			
			break;
		}
		
		// randomly pick the object and spawn it
		float randFloat = Random.Range (0.0f, 1.0f);
		int objIndex = 0;
		float testValue = 0.0f;
		
		for(; objIndex < obstacleSpawnChanceArray.Length; ++objIndex)
		{
			testValue += obstacleSpawnChanceArray[objIndex];
			
			if(testValue >= randFloat)
				break;
		}
		
		MonoBehaviour.Instantiate (obstacleArray[objIndex], spawnPosition, Quaternion.identity);

	}

	// collectables will spawn 1 by 1
	// after a collectable gets taken, collectable will have a onDestroy that calls this function and 
	// the winlose manager's ReduceObjectCount
	public void SpawnCollectible()
	{
		Vector2 screenPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
		Vector3 spawnPosition = new Vector3(screenPosition.x, screenPosition.y, 0f);

		// retrieve for checks
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		GameObject[] listOfObstacles = GameObject.FindGameObjectsWithTag("Enemy");

		if (player == null)
			Debug.LogError  ("CollectorSpawnerScript::SpawnCollectable - player can't be found!");
		
		// randomly find a position to spawn the collectable
		// if collectable is colliding with player, redo
		bool check = false;

		while (true) 
		{
			Vector3 distanceVector = spawnPosition - player.transform.position;
			// first check against player
			if(distanceVector.sqrMagnitude < sqDistFromPlayer)
			{
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
				continue;
			}

			// second check against all obstacles
			check = true;
			for(int i = 0; i < listOfObstacles.Length; ++i)
			{
				distanceVector = spawnPosition - listOfObstacles[i].transform.position;
				if(distanceVector.sqrMagnitude < sqDistFromObstacle){
					check = false;
					break;
				}
			}

			if(!check){
				spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
				continue;
			}

			break;
		}
		
		// randomly pick the object and spawn it
		float randFloat = Random.Range (0.0f, 1.0f);
		int objIndex = 0;
		float testValue = 0.0f;
		
		for(; objIndex < collectibleSpawnChanceArray.Length; ++objIndex)
		{
			testValue += collectibleSpawnChanceArray[objIndex];
			
			if(testValue >= randFloat)
				break;
		}
		
		MonoBehaviour.Instantiate (collectibleArray[objIndex], spawnPosition, Quaternion.identity);
	}
	
}
