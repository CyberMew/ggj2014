using UnityEngine;
using System.Collections;

public class CollectorSpawnerScript : MonoBehaviour {
	
	public GameObject[] collectibleArray;
	public float[] collectibleSpawnChanceArray;

	public GameObject[] obstacleArray;
	public float[] obstacleSpawnChanceArray;

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
	
	// Update is called once per frame
	void Update () {
	}

	// create obstacle
	// create collectable

	// obstacles remove themselves periodically
	// calls for new obstacles to be created after delay X
	// change obstacle count every Y seconds

	// collectables will spawn 1 by 1
	// after a collectable gets taken, collectable will have a onDestroy that calls this function and 
	// the winlose manager's ReduceObjectCount
	// screenToWorldPoint
	// 1024 x 768
	void SpawnCollectable()
	{
		Vector2 spawnPosition = new Vector2(0,0);

		// randomly select one of the collectables to spawn
		float randFloat = Random.Range (0.0f, 1.0f);
		float testValue = 0.0f;
		int index = 0;

		while (testValue <= randFloat)
		{
			testValue += collectibleSpawnChanceArray[index];
			++index;
		}

		// randomly find a position to spawn the collectable
		// if collectable is colliding with anything, redo
		bool isLegalPosition = false;
		while (!isLegalPosition) 
		{
			// check collision

			isLegalPosition = true;
		}

		// spawn the object
		Instantiate (collectibleArray [index], spawnPosition, Quaternion.identity);
	}

	
}
