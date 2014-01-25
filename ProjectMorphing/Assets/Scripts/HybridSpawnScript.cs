using UnityEngine;
using System.Collections;

public class HybridSpawnScript : MonoBehaviour {

	public GameObject[] enemyArray;

	public GameObject[] buffArray;
	public float[] buffSpawnChanceArray;
	
	public float initialBuffDelay;

	public float minBuffDelay;
	public float maxBuffDelay;

	public float sqDistFromPlayer;

	// Use this for initialization
	void Start () {
	
		// check buff spawn chances
		float totalBuffPercentage = 0.0f;
		for (int i = 0; i < buffSpawnChanceArray.Length; ++i)
			totalBuffPercentage += buffSpawnChanceArray[i];
		
		if(totalBuffPercentage > 1.0f)
			Debug.Log ("HybridSpawnScript::Start() - total combined percentage for buff spawn chance exceeds 1!");
		else if(totalBuffPercentage < 1.0f)
			Debug.Log ("HybridSpawnScript::Start() - total combined percentage for buff spawn chance is less than 1!");

		// start the buff spawning cycle
		StartCoroutine (SpawnBuffIfApplicable ());

	}
	

	IEnumerator SpawnBuffIfApplicable()
	{
		yield return new WaitForSeconds (initialBuffDelay);
		
		while (true)
		{
			// pick a buff randomly
			float randFloat = Random.Range (0.0f, 1.0f);
			int buffIndex = 0;
			float testValue = 0.0f;
			
			for(; buffIndex < buffSpawnChanceArray.Length; ++buffIndex)
			{
				testValue += buffSpawnChanceArray[buffIndex];
				
				if(testValue >= randFloat)
					break;
			}
			
			// spawn a new position for the buff that is not colliding with the player
			// can be colliding with enemy
			Vector2 screenPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
			Vector3 spawnPosition = new Vector3(screenPosition.x, screenPosition.y, 0f);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			
			if (player == null)
				Debug.LogError  ("ShooterSpawnScript::SpawnBuffIfApplicable - player can't be found!");
			
			bool isLegalPosition = false;
			
			while(!isLegalPosition)
			{
				Vector3 distanceVector = spawnPosition - player.transform.position;
				if(distanceVector.sqrMagnitude > sqDistFromPlayer)
					isLegalPosition = true;
				else
					spawnPosition = new Vector2(Random.Range(MySystem.edgeLeft,MySystem.edgeRight), Random.Range(MySystem.edgeBottom,MySystem.edgeTop));
			}
			
			// create the buff
			Instantiate(buffArray[buffIndex], spawnPosition, Quaternion.identity);
			
			// generate new wait time
			yield return new WaitForSeconds (Random.Range (minBuffDelay, maxBuffDelay));
		}
		
	}


	// spawn an enemy based on the index given
	void SpawnEnemy(int enemyIndex)
	{
		SpawnTemplate.SpawnObject (ref enemyArray [enemyIndex], sqDistFromPlayer);
	}


}
