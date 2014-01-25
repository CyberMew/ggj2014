using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	public string sceneName = "MainMenu";

	private bool confirmQuit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUpAsButton()
	{
		if(sceneName == "Exit" || sceneName == "Quit")
		{
			// Popup confirmation here
			confirmQuit = true;
		}
		else
		{
			Application.LoadLevel(sceneName);
		}
	}

	void OnGUI()
	{
		if(confirmQuit)
		{
			float centerX = Screen.width * 0.5f;
			
			float boxWidth = 400f;
			float boxHeight = 280f;
			Rect rect = new Rect(centerX - boxWidth * 0.5f, 200f, boxWidth, boxHeight);
			// Always Display normal buttons (Resume, Restart, Main Menu, Quit)
			GUI.Box(rect, "\n\nThis is your final chance. Do what you deem fit.");
			
			// Make all rect positions relative to the box's rect
			GUI.BeginGroup(rect);
			float buttonWidth = 150f;
			float buttonHeight = 60f;
			centerX = boxWidth * 0.5f - buttonWidth * 0.5f;
			//	Start draw Resume button
			if(GUI.Button(new Rect(centerX, 90f, buttonWidth, buttonHeight), new GUIContent("Quit this now!")))
			{
				Application.Quit();
			}
			//	Start draw Restart button
			if(GUI.Button(new Rect(centerX, 90f + buttonHeight + 30f, buttonWidth, buttonHeight), new GUIContent("Alright I'll stay.")))
			{
				confirmQuit = false;
			}
			GUI.EndGroup();
		}
	}
}
