using UnityEngine;
using System.Collections;

public class SpawnNewCollectibleOnDeath : MonoBehaviour {

	// Use this for initialization
	void OnDestroy()
	{
		GameObject spawnManager = GameObject.FindGameObjectWithTag("CollectorSpawnManager");

		if (spawnManager) {
			spawnManager.GetComponent<CollectorSpawnerScript>().SpawnCollectible();
		}
	}
}
