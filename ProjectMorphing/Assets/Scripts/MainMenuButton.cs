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
			
			Rect rect = new Rect(centerX, MySystem.sHEIGHT * 0.2f, 400f, 400f);
			// Always Display normal buttons (Resume, Restart, Main Menu, Quit)
			GUI.Box(rect, "This is your final chance. Do what you deem fit.");
			
			// Make all rect positions relative to the box's rect
			GUI.BeginGroup(rect);
			//	Start draw Resume button
			if(GUI.Button(new Rect(0f, 0f, 100f, 20f), new GUIContent("Quit this now!")))
			{
				Application.Quit();
			}
			//	Start draw Restart button
			if(GUI.Button(new Rect(0f, 40f, 100f, 20f), new GUIContent("Alright I'll stay.")))
			{
				confirmQuit = false;
			}
			GUI.EndGroup();
		}
	}
}
