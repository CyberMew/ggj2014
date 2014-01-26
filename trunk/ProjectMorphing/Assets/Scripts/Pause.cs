using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GUISkin guiSkin;

	private float prevTimeScale;

	// Use this for initialization
	void Start () {

		prevTimeScale = Time.timeScale;
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destroy()
	{
		Time.timeScale = prevTimeScale;
	}

	private bool isAskForConfirmation = false;
	//private bool isEventResultWaiting = false;


	private enum RESULTS
	{
		DONOTHING,
		WAITING,
		RESTART,
		QUITGAME,
		GOTOMENU
	}
	private RESULTS eventResults = RESULTS.DONOTHING;

	// There are lots of ways to implement GUI, and this is one of them (using the old system of UnityGUI)
	void OnGUI()	// Note this function is a state machine
	{
		/*if(Application.isLoadingLevel)
		{
			Debug.Log("skip draw");
			return;
		}*/

		// Stop applying the previous custom skin and apply our own custom skin for this render phase
		GUISkin previousSkin = GUI.skin;
		GUI.skin = guiSkin;

		// Backup the current matrix
		Matrix4x4 oldMtx = GUI.matrix;
		// Applying the matrix so that the buttons will scale in position and size accordingly to screen
		float centerX = Screen.width * 0.5f;
		GUIUtility.ScaleAroundPivot(new Vector2(Screen.width/MySystem.sWIDTH, Screen.height/MySystem.sHEIGHT), new Vector2(centerX, 0f));

		// This MIGHT have to be shifted after drawmainpause
		if(isAskForConfirmation)
		{
			// Draw the confirmation popup
			if(DrawConfirmationMenu()) // User click Yes (true) OR No (false) - i.e. they responded
			{
				// Do not have to ask again
				isAskForConfirmation = false;
				// Process the type of event result the Yes corresponds to
				switch(eventResults)
				{
				case RESULTS.DONOTHING: // Detected user clicked No
					// Do nothing
					break;
				case RESULTS.RESTART:
					Application.LoadLevel(Application.loadedLevelName);
					break;
				case RESULTS.GOTOMENU:
					Application.LoadLevel("MainMenu");
					break;
				case RESULTS.QUITGAME:
					Application.Quit();
					break;
				}
				
				// After processing, turn it off
				eventResults = RESULTS.DONOTHING;
			}

			if(Event.current.keyCode == KeyCode.Escape)
			{
				// Message was cancelled by clicking No (false) or was cancelled by keypress
				isAskForConfirmation = false;
				Event.current.Use();
			}

			// Then disable the GUI
			GUI.enabled = false;
		}
		else
		{
			if(Event.current.keyCode == KeyCode.Escape)
			{
				// Terminate this object
				Destroy(this.gameObject);
			}
		}
		DrawMainPauseMenu();

		// No matter what, resume the enable for the next phase
		GUI.enabled = true;

		// Restore back the custom skin used by other scripts
		GUI.skin = previousSkin;
	}

	void DrawMainPauseMenu()
	{
		float centerX = Screen.width * 0.5f;

		float boxWidth = 400f;
		float boxHeight = 450f;


		Rect rect = new Rect(centerX - boxWidth * 0.5f, 200f, boxWidth, boxHeight);
		// Always Display normal buttons (Resume, Restart, Main Menu, Quit)
		GUI.Box(rect, "\n\nGame Paused");

		float buttonWidth = 160f;
		float buttonHeight = 60f;
		centerX = boxWidth * 0.5f - buttonWidth * 0.5f;
		// Make all rect positions relative to the box's rect
		GUI.BeginGroup(rect);
		//	Start draw Resume button
		if(GUI.Button(new Rect(centerX, 90f, buttonWidth, buttonHeight), new GUIContent("Resume")))
		{
			Destroy(this.gameObject);
		}
		//	Start draw Restart button
		if(GUI.Button(new Rect(centerX, 90f + buttonHeight + 20f, buttonWidth, buttonHeight), new GUIContent("Restart the Level")))
		{
			isAskForConfirmation = true;
			eventResults = RESULTS.RESTART;
		}
		//	Start draw Main Menu button
		if(GUI.Button(new Rect(centerX, 90f + 2 * (buttonHeight + 20f), buttonWidth, buttonHeight), new GUIContent("Back to Menus")))
		{
			isAskForConfirmation = true;
			eventResults = RESULTS.GOTOMENU;
		}
		//	Start draw Quit Game button
		if(GUI.Button(new Rect(centerX, 90f + 3 * (buttonHeight + 20f), buttonWidth, buttonHeight), new GUIContent("Terminate Game")))
		{
			isAskForConfirmation = true;
			eventResults = RESULTS.QUITGAME;
		}
		GUI.EndGroup();
	}

	// Returns Yes (true) or No (false) by the confirmation buttons
	bool DrawConfirmationMenu()
	{
		bool isConfirmed = false;
		float centerX = Screen.width * 0.5f;

		float boxWidth = 400f;
		float boxHeight = 440f;
		Rect rect = new Rect(centerX - boxWidth * 0.5f, 200f, boxWidth, boxHeight);
		// Always Display normal buttons (Resume, Restart, Main Menu, Quit)
		GUI.Box(rect, "Are you sure you want to do this?");
		
		// Make all rect positions relative to the box's rect
		GUI.BeginGroup(rect);
		//	Start draw Resume button
		if(GUI.Button(new Rect(boxWidth * 0.5f, 100f, 100f, 100f), new GUIContent("Yes")))
		{
			isConfirmed = true;
		}
		//	Start draw Restart button
		if(GUI.Button(new Rect(boxWidth * 0.5f, 150f, 100f, 100f), new GUIContent("No")))
		{
			isConfirmed = true;
		}
		GUI.EndGroup();

		// Return output result
		return isConfirmed;
	}
}
