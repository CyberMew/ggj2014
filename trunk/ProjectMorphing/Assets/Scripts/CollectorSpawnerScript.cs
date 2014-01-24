using UnityEngine;
using System.Collections;

public class CollectorSpawnerScript : MonoBehaviour {
	
	public GameObject[] collectableArray;
	public GameObject[] obstacleArray;

	// Use this for initialization
	void Start () {
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
		int arrayPos = Random.Range (0, collectableArray.Length-1);

		// randomly find a position to spawn the collectable
		// if collectable is colliding with anything, redo
		bool isLegalPosition = false;
		while (!isLegalPosition) 
		{
			// check collision

			isLegalPosition = true;
		}

		// spawn the object
		Instantiate (collectableArray [arrayPos], spawnPosition, Quaternion.identity);
	}
}
