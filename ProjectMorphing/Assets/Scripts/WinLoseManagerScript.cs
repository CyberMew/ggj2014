using UnityEngine;
using System.Collections;

public class WinLoseManagerScript : MonoBehaviour {

	public int InitialObjectCount = 150;
	public GameObject DisplayStatsObj;

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
	public void WinGame()
	{
		Instantiate(DisplayStatsObj);
		Debug.Log("Won, instantiated");
		Time.timeScale = 0f;
	}

	// called when the player is killed
	// show a display
	public void LoseGame()
	{
		Instantiate(DisplayStatsObj);
		Debug.Log("Lost, instantiated");
		Time.timeScale = 0f;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			LoseGame();
		}
	}
}
