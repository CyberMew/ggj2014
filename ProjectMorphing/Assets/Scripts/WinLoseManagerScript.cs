using UnityEngine;
using System.Collections;

public class WinLoseManagerScript : MonoBehaviour {

	public int objectsToSpawn = 200;

	// Use this for initialization
	void Start () {
	
	}

	// reduce an object count
	// works for either collecting collectables or killing enemies
	void ReduceObjectCount()
	{
		--objectsToSpawn;

		if (objectsToSpawn <= 0)
			WinGame ();
	}

	// win the game
	// show a display
	void WinGame()
	{
	}

	// called when the player is killed
	// show a display
	void LoseGame()
	{
	}

}
