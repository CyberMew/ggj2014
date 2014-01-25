using UnityEngine;
using System.Collections;

public class WinLoseManagerScript : MonoBehaviour {

	public int InitialObjectCount = 200;
	private int currObjectCount;

	// Use this for initialization
	void Start () {
		currObjectCount = InitialObjectCount;
	}

	// reduce an object count
	// works for either collecting collectables or killing enemies
	public void ReduceObjectCount()
	{
		--currObjectCount;

		if (currObjectCount <= 0)
			WinGame ();
	}

	public int GetCurrObjectCount()
	{
		return currObjectCount;
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
