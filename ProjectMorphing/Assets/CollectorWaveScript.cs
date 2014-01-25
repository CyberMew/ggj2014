using UnityEngine;
using System.Collections;

[System.Serializable]
public class ObstacleToObjectRatio
{
	public int obstacleCount;
	public int objectCount;
}

public class CollectorWaveScript : MonoBehaviour {

	public GameObject masterCollectorSpawnManager;
	private GameObject spawnManager;

	public int initialObstacleCount;

	private int currIndex;
	private int currMaxObstacleCount;

	public ObstacleToObjectRatio[] ratioArray;

	// Use this for initialization
	void Start () {
	
		spawnManager = (GameObject)Instantiate (masterCollectorSpawnManager, new Vector3 (), Quaternion.identity);

		currIndex = 0;
		currMaxObstacleCount = initialObstacleCount;

		for (int i = 0; i < initialObstacleCount; ++i)
			spawnManager.GetComponent<CollectorSpawnerScript> ().SpawnObstacle ();

		// create initial collectible
		spawnManager.GetComponent<CollectorSpawnerScript> ().SpawnCollectible ();
	}
	
	// Update is called once per frame
	void Update () {
	
		// add obstacles as more and more objects are taken
		GameObject winLoseManager = GameObject.FindGameObjectWithTag ("WinLoseManager");

		if (winLoseManager == null)
						Debug.LogError ("CollectorWaveScript::Update() - winLoseManager not created yet!");

		int currObjectCount = winLoseManager.GetComponent<WinLoseManagerScript> ().GetCurrObjectCount();

		if (currObjectCount < ratioArray [currIndex].objectCount)
			currMaxObstacleCount = ratioArray [++currIndex].obstacleCount;

		// ensure obstacles are recreated if destroyed
		int currObstacleCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if (currObstacleCount < currMaxObstacleCount) {

			int difference = currMaxObstacleCount - currObstacleCount;

			for(int i = 0; i < difference; ++i)
				spawnManager.GetComponent<CollectorSpawnerScript> ().SpawnObstacle();
		}

	}


}
