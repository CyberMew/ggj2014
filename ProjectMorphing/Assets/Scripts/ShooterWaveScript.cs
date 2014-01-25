using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TotalCount
{	
	public int firstCount = 0;
	public int secondCount = 0;
	public int thirdCount = 0;
	public int fourthCount = 0;
}

public class ShooterWaveScript : MonoBehaviour {

	public GameObject masterShooterSpawnManager;
	private GameObject spawnManager;

	private delegate void WaveDelegate();
	/*private WaveDelegate[] arrayOfEasyWaves;
	private WaveDelegate[] arrayOfMediumWaves;
	private WaveDelegate[] arrayOfHardWaves;*/
	
	private List<WaveDelegate> listOfEasyWaves = new List<WaveDelegate>();
	private List<WaveDelegate> listOfMediumWaves = new List<WaveDelegate>();
	private List<WaveDelegate> listOfHardWaves = new List<WaveDelegate>();

	public float initialDelay;
	public float minDelayBeforeSpawn;
	public float maxDelayBeforeSpawn;
	public ENEMYDIFFICULTY[] orderToSpawn;
	
	private float spawnTimer = 0f;
	private Queue<ENEMYDIFFICULTY> spawnOrder = new Queue<ENEMYDIFFICULTY>();
	
	public TotalCount[] EasyWavesVarients;
	public TotalCount[] MediumWavesVarients;
	public TotalCount[] HardWavesVarients;

	// Use this for initialization
	void Start () {
		spawnManager = (GameObject)Instantiate (masterShooterSpawnManager, new Vector3 (), Quaternion.identity);

		// initialize arrays
		//int index = 0;
		/*listOfEasyWaves.Add(() => Spawn (5,0));
		listOfEasyWaves.Add(() => Spawn (0,5));
		listOfEasyWaves.Add(() => Spawn (3,3));
		listOfEasyWaves.Add(() => Spawn (2,4));
		listOfEasyWaves.Add(() => Spawn (4,2));*/
		foreach(TotalCount tc in EasyWavesVarients)
		{
			listOfEasyWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));
		}
		/*arrayOfEasyWaves [index++] = (() => Spawn (5,0));
		arrayOfEasyWaves [index++] = (() => Spawn (0,5));
		arrayOfEasyWaves [index++] = (() => Spawn (3,3));
		arrayOfEasyWaves [index++] = (() => Spawn (2,4));
		arrayOfEasyWaves [index++] = (() => Spawn (4,2));*/



		//index = 0;
		/*listOfMediumWaves.Add(() => Spawn (4,2,1));
		listOfMediumWaves.Add(() => Spawn (3,2,2));
		listOfMediumWaves.Add(() => Spawn (2,4,1));
		listOfMediumWaves.Add(() => Spawn (2,3,2));
		listOfMediumWaves.Add(() => Spawn (2,2,3));*/
		foreach(TotalCount tc in HardWavesVarients)
		{
			listOfMediumWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));
		}
		/*
		arrayOfMediumWaves[index++] = (() => Spawn (4,2,1));
		arrayOfMediumWaves[index++] = (() => Spawn (3,2,2));
		arrayOfMediumWaves[index++] = (() => Spawn (2,4,1));
		arrayOfMediumWaves[index++] = (() => Spawn (2,3,2));
		arrayOfMediumWaves[index++] = (() => Spawn (2,2,3));*/

		
		/*listOfHardWaves.Add(() => Spawn (0,4,3,2));
		listOfHardWaves.Add(() => Spawn (0,3,4,2));
		listOfHardWaves.Add(() => Spawn (0,3,3,3));
		listOfHardWaves.Add(() => Spawn (0,2,3,4));
		listOfHardWaves.Add(() => Spawn (0,1,4,4));*/
		foreach(TotalCount tc in HardWavesVarients)
		{
			listOfHardWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));
		}
		/*index = 0;
		arrayOfHardWaves[index++] = (() => Spawn (0,4,3,2));
		arrayOfHardWaves[index++] = (() => Spawn (0,3,4,2));
		arrayOfHardWaves[index++] = (() => Spawn (0,3,3,3));
		arrayOfHardWaves[index++] = (() => Spawn (0,2,3,4));
		arrayOfHardWaves[index++] = (() => Spawn (0,1,4,4));*/

		// Set initial spawn time
		spawnTimer = initialDelay;

		// Convert the array to Queue
		foreach(ENEMYDIFFICULTY diff in orderToSpawn)
		{
			spawnOrder.Enqueue(diff);
		}
	}

	
/*---------------------------------------------------------------------------------------------------------------------------*/

	void Spawn(int firstCount, int secondCount = 0, int thirdCount = 0, int fourthCount = 0)
	{
		for(int i = 0; i < firstCount; ++i)
				spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (0);

		for(int i = 0; i < secondCount; ++i)
				spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (1);

		for(int i = 0; i < thirdCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (2);
		
		for(int i = 0; i < fourthCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (3);
	}

	public enum ENEMYDIFFICULTY
	{
		EASY,
		MEDIUM,
		HARD
	}

	void Update()
	{
		/*if(Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log("Calling a set of easy wave");
			int index = Random.Range(0,4);
			listOfEasyWaves[index]();
		}*/

		spawnTimer -= Time.deltaTime;
		if(spawnTimer < 0f && spawnOrder.Count > 0)
		{
			// Reset the timer for next spawn
			spawnTimer = Random.Range(minDelayBeforeSpawn, maxDelayBeforeSpawn);

			int index = 0;
			// Actually spawn some wave
			switch(spawnOrder.Dequeue())
			{
			case ENEMYDIFFICULTY.EASY:
				index = Random.Range(0,listOfEasyWaves.Count);
				listOfEasyWaves[index]();
				Debug.Log("Spawning Easy Wave");
				break;
			case ENEMYDIFFICULTY.MEDIUM:
				index = Random.Range(0,listOfMediumWaves.Count);
				listOfMediumWaves[index]();
				Debug.Log("Spawning Medium Wave");
				break;
			case ENEMYDIFFICULTY.HARD:
				index = Random.Range(0,listOfHardWaves.Count);
				listOfHardWaves[index]();
				Debug.Log("Spawning Hard Wave");
				break;
			}
		}
	}
}
