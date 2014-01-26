using UnityEngine;
using System.Collections;

public class WinLoseManagerScript : MonoBehaviour {

	public int InitialObjectCount = 150;
	public GameObject DisplayStatsObj;

	private int currObjectCount;

	private enum GAMESTATE
	{
		UNDETERMINED,
		WIN,
		LOSE
	}
	private GAMESTATE gameState;

	// Use this for initialization
	void Start () {
		currObjectCount = InitialObjectCount;
		gameState = GAMESTATE.UNDETERMINED;
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
		gameState = GAMESTATE.WIN;
	}

	// called when the player is killed
	// show a display
	public void LoseGame()
	{
		Instantiate(DisplayStatsObj);
		Debug.Log("Lost, instantiated");
		Time.timeScale = 0f;
		gameState = GAMESTATE.LOSE;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			LoseGame();
		}
	}

	void OnGUI()
	{
		// Backup the current matrix
		Matrix4x4 oldMtx = GUI.matrix;
		// Applying the matrix so that the buttons will scale in position and size accordingly to screen
		GUIUtility.ScaleAroundPivot(new Vector2(Screen.width/MySystem.sWIDTH, Screen.height/MySystem.sHEIGHT), new Vector2(0f, 0f));
		
		GUIStyle textTitle = new GUIStyle(GUI.skin.GetStyle("Label"));
		textTitle.alignment = TextAnchor.MiddleCenter;
		textTitle.fontSize = 30;
		textTitle.fontStyle = FontStyle.Bold;

		if(gameState == GAMESTATE.LOSE)
		{
			GUI.Label(new Rect(Screen.width * 0.5f - 250f, 200f, 500, 50f), "YOU LOSE");
		}
		else
		{
			GUI.Label(new Rect(Screen.width * 0.5f - 200f, 200f, 500, 50f), "YOU WON");
		}
	}
}
