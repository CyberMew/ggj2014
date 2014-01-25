using UnityEngine;
using System.Collections;

public class ShooterWaveScript : MonoBehaviour {

	public GameObject masterShooterSpawnManager;
	private GameObject spawnManager;

	private delegate void WaveDelegate();
	private WaveDelegate[] arrayOfEasyWaves;
	private WaveDelegate[] arrayOfMediumWaves;
	private WaveDelegate[] arrayOfHardWaves;

	public float initialDelay;
	public float minDelayBeforeSpawn;
	public float maxDelayBeforeSpawn;


	// Use this for initialization
	void Start () {
		spawnManager = (GameObject)Instantiate (masterShooterSpawnManager, new Vector3 (), Quaternion.identity);

		// initialize arrays
		int index = 0;
		arrayOfEasyWaves [index++] = (() => Spawn (5,0));
		arrayOfEasyWaves [index++] = (() => Spawn (0,5));
		arrayOfEasyWaves [index++] = (() => Spawn (3,3));
		arrayOfEasyWaves [index++] = (() => Spawn (2,4));
		arrayOfEasyWaves [index++] = (() => Spawn (4,2));


		arrayOfEasyWaves [0] ();

		index = 0;
		arrayOfMediumWaves[index++] = (() => Spawn (4,2,1));
		arrayOfMediumWaves[index++] = (() => Spawn (3,2,2));
		arrayOfMediumWaves[index++] = (() => Spawn (2,4,1));
		arrayOfMediumWaves[index++] = (() => Spawn (2,3,2));
		arrayOfMediumWaves[index++] = (() => Spawn (2,2,3));

		index = 0;
		arrayOfHardWaves[index++] = (() => Spawn (0,4,3,2));
		arrayOfHardWaves[index++] = (() => Spawn (0,3,4,2));
		arrayOfHardWaves[index++] = (() => Spawn (0,3,3,3));
		arrayOfHardWaves[index++] = (() => Spawn (0,2,3,4));
		arrayOfHardWaves[index++] = (() => Spawn (0,1,4,4));
	}

	
/*---------------------------------------------------------------------------------------------------------------------------*/

	void Spawn(int firstCount, int secondCount = 0, int thirdCount = 0, int fourthCount = 0)
	{
		for(int i = 0; i < firstCount; ++i)
				spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (0);

		for(int i = 0; i < secondCount; ++i)
				spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (1);

		for(int i = 0; i < firstCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (2);
		
		for(int i = 0; i < secondCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (3);
	}
		
}
