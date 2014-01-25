using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TotalCountShooter
{	
	public int firstCount = 0;
	public int secondCount = 0;
	public int thirdCount = 0;
	public int fourthCount = 0;
}

//public enum WAVEACTION
//{
//	SPAWN_EASY_WAVE,
//	SPAWN_MEDIUM_WAVE,
//	SPAWN_HARD_WAVE,
//	DELAY_MIN_DURATION,
//	DELAY_MAX_DURATION,
//	DELAY_RAND_DURATION
//}

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
	public float minSpawnDelay;
	public float maxSpawnDelay;
	public WAVEACTION[] waveActionOrder;

	private Queue<WAVEACTION> waveActionQueue = new Queue<WAVEACTION>();
	
	public TotalCountShooter[] EasyWavesVariants;
	public TotalCountShooter[] MediumWavesVariants;
	public TotalCountShooter[] HardWavesVariants;

	// Use this for initialization
	void Start () {
		spawnManager = (GameObject)Instantiate (masterShooterSpawnManager, new Vector3 (), Quaternion.identity);

		// initialize arrays
		foreach(TotalCountShooter tc in EasyWavesVariants)
			listOfEasyWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));

		foreach(TotalCountShooter tc in HardWavesVariants)
			listOfMediumWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));

		foreach(TotalCountShooter tc in HardWavesVariants)
			listOfHardWaves.Add(() => Spawn (tc.firstCount, tc.secondCount, tc.thirdCount, tc.fourthCount));

		// Convert the array to Queue
		foreach(WAVEACTION diff in waveActionOrder)
			waveActionQueue.Enqueue(diff);

		StartCoroutine (WaveSpawning ());
	}


	IEnumerator WaveSpawning()
	{
		// wait the initial delay
		yield return new WaitForSeconds (initialDelay);

		while (true) {

			// while queue still has actions within
			if (waveActionQueue.Count > 0) {
				
				switch(waveActionQueue.Dequeue())
				{
				case WAVEACTION.SPAWN_EASY_WAVE:
					listOfEasyWaves[Random.Range(0,listOfEasyWaves.Count-1)]();
					//Debug.Log("Spawning Easy Wave");
					break;
				case WAVEACTION.SPAWN_MEDIUM_WAVE:
					listOfMediumWaves[Random.Range(0,listOfMediumWaves.Count-1)]();
					//Debug.Log("Spawning Medium Wave");
					break;
				case WAVEACTION.SPAWN_HARD_WAVE:
					listOfHardWaves[Random.Range(0,listOfHardWaves.Count-1)]();
					//Debug.Log("Spawning Hard Wave");
					break;
				case WAVEACTION.DELAY_MIN_DURATION:
					yield return new WaitForSeconds (minSpawnDelay);
					break;
				case WAVEACTION.DELAY_MAX_DURATION:
					yield return new WaitForSeconds (maxSpawnDelay);
					break;
				case WAVEACTION.DELAY_RAND_DURATION:
					yield return new WaitForSeconds (Random.Range(minSpawnDelay, maxSpawnDelay));
					break;
				}
				
			}
			// if queue has no more actions, simply spawn hard waves for random seconds
			else {
				yield return new WaitForSeconds (Random.Range(minSpawnDelay, maxSpawnDelay));
				listOfHardWaves[Random.Range(0,listOfHardWaves.Count-1)]();
			}
		}

	}


	void Spawn(int firstObjCount, int secondObjCount = 0, int thirdObjCount = 0, int fourthObjCount = 0)
	{
		for(int i = 0; i < firstObjCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (0);

		for(int i = 0; i < secondObjCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (1);

		for(int i = 0; i < thirdObjCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (2);
		
		for(int i = 0; i < fourthObjCount; ++i)
			spawnManager.GetComponent<ShooterSpawnScript> ().SpawnEnemy (3);
	}
	
}
