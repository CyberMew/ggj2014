using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	public string sceneName = "MainMenu";

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
			// todo: popup confirmation here
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(sceneName);
		}
	}
}
