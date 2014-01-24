using UnityEngine;
using System.Collections;

public class HybridSpawnScript : MonoBehaviour {

	public GameObject[] enemyArray;

	public GameObject[] buffArray;
	public float[] buffSpawnChanceArray;
	
	public float initialBuffDelay;
	private float delayBeforeBuffSpawns;

	// Use this for initialization
	void Start () {
	
		// check buff spawn chances
		float totalBuffPercentage = 0.0f;
		for (int i = 0; i < buffSpawnChanceArray.Length; ++i)
			totalBuffPercentage += buffSpawnChanceArray[i];
		
		if(totalBuffPercentage > 1.0f)
			Debug.Log ("ShooterSpawnScript::Start() - total combined percentage for buff spawn chance exceeds 1!");
		else if(totalBuffPercentage < 1.0f)
			Debug.Log ("ShooterSpawnScript::Start() - total combined percentage for buff spawn chance is less than 1!");
		
		
		// give an initial delay before buff spawns
		delayBeforeBuffSpawns = initialBuffDelay;
		
		// start the buff spawning cycle
		StartCoroutine (SpawnBuffIfApplicable ());

	}
	
	// Update is called once per frame
	void Update () {
	}


	// spawn a buff if applicable
	IEnumerator SpawnBuffIfApplicable()
	{
		yield return new WaitForSeconds (delayBeforeBuffSpawns);
		
		while (true)
		{
			// pick a buff randomly
			float randFloat = Random.Range (0.0f, 1.0f);
			int buffIndex = 0;
			float testValue = 0.0f;
			
			while (testValue <= randFloat)
			{
				testValue += buffSpawnChanceArray[buffIndex];
				++buffIndex;
			}
			
			// spawn a new position for the buff that is not colliding with the player
			// can be colliding with enemy
			Vector2 spawnPosition = new Vector2(0,0);
			bool isLegalPosition = false;
			
			while(!isLegalPosition)
			{
				// check for collision with player object //////////////////////////////////////////////////////////////////////////////////
				isLegalPosition = true;
			}
			
			// create the buff
			Instantiate(buffArray[buffIndex], spawnPosition, Quaternion.identity);
			
			// generate new wait time
			delayBeforeBuffSpawns = Random.Range (0.0f, delayBeforeBuffSpawns);
			yield return new WaitForSeconds (delayBeforeBuffSpawns);
		}
		
	}


	// spawn an enemy based on the index given
	void SpawnEnemy(int enemyIndex)
	{
		Vector2 spawnPosition = new Vector2(0,0);
		
		// randomly find a position to spawn the collectable
		// if collectable is colliding with anything, redo
		bool isLegalPosition = false;
		while (!isLegalPosition) 
		{
			// check collision //////////////////////////////////////////////////////////////////////////////////////////////////////////
			isLegalPosition = true;
		}
		
		// spawn the object
		Instantiate (enemyArray[enemyIndex], spawnPosition, Quaternion.identity);
	}


}
