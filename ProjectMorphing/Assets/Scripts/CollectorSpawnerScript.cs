using UnityEngine;
using System.Collections;

public class CollectorSpawnerScript : MonoBehaviour {
	
	public GameObject[] collectibleArray;
	public float[] collectibleSpawnChanceArray;

	public GameObject[] obstacleArray;
	public float[] obstacleSpawnChanceArray;

	public float sqDistFromPlayer;

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

	// collectables will spawn 1 by 1
	// after a collectable gets taken, collectable will have a onDestroy that calls this function and 
	// the winlose manager's ReduceObjectCount
	void SpawnCollectable()
	{
		SpawnTemplate.SpawnObject (ref collectibleArray, ref collectibleSpawnChanceArray, sqDistFromPlayer);
	}

	
}
