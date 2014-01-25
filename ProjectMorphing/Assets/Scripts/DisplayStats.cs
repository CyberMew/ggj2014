using UnityEngine;
using System.Collections;

public class DisplayStats : MonoBehaviour {

	private StatsManager stats;
	private int shooterPlays = 0;
	private int collectiblePlays = 0;
	private int hybridPlays = 0;
	// Use this for initialization
	void Start () {
		//stats = this.gameObject.AddComponent<StatsManager>();//new StatsManager();
		stats = GameObject.Find("StatsManager").GetComponent<StatsManager>();

		collectiblePlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.COLLECTIBLE);
		shooterPlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.SHOOTER);
		hybridPlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.HYBRID);

		stats.SetIncrementGameModeStatsByOne(StatsManager.MODES.COLLECTIBLE);
	}

	void OnEnable()
	{
	//	stats = this.gameObject.AddComponent<StatsManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// Whe
		if(Input.GetKeyDown(KeyCode.T))
		{
			//Debug.Log(stats.GetCurrentTotalModeStats(StatsManager.MODES.SHOOTER).ToString());
			//Debug.Log(stats.GetCurrentTotalModeStats(StatsManager.MODES.COLLECTIBLE).ToString());
			collectiblePlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.COLLECTIBLE);
			shooterPlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.SHOOTER);
			hybridPlays = stats.GetCurrentTotalModeStats(StatsManager.MODES.HYBRID);
		}
	}

	void OnGUI()
	{
		GUIStyle textTitle = new GUIStyle(GUI.skin.GetStyle("Label"));
		textTitle.alignment = TextAnchor.MiddleLeft;
		//textTitle.font = new Font("Times New Roman");
		textTitle.fontSize = 40;
		float labelHeight = 50f;
		float labelWidth = 500f;

		float xPos = 200f;
		float yPos = 120f;

		GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), "Shooter", textTitle);
		
		GUI.Label(new Rect(xPos, yPos + 200f, labelWidth, labelHeight), "Collectible", textTitle);
		
		GUI.Label(new Rect(xPos, yPos + 400f, labelWidth, labelHeight), "Hybrid", textTitle);

		textTitle.fontSize = 30;

		xPos = 370f;
		yPos = 165f;
		GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), "Plays", textTitle);
		GUI.Label(new Rect(xPos, yPos + 200f, labelWidth, labelHeight), "Plays", textTitle);
		GUI.Label(new Rect(xPos, yPos + 400f, labelWidth, labelHeight), "Plays", textTitle);

		textTitle.alignment = TextAnchor.MiddleRight;
		
		xPos = 200f;
		yPos = 165f;
		labelWidth = 150f;
		GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), shooterPlays.ToString(), textTitle);
		GUI.Label(new Rect(xPos, yPos + 200f, labelWidth, labelHeight), collectiblePlays.ToString(), textTitle);
		GUI.Label(new Rect(xPos, yPos + 400f, labelWidth, labelHeight), hybridPlays.ToString(), textTitle);
		/*
		GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), "1111", textTitle);
		GUI.Label(new Rect(xPos, yPos + 200f, labelWidth, labelHeight), "111", textTitle);
		GUI.Label(new Rect(xPos, yPos + 400f, labelWidth, labelHeight), "11", textTitle);
*/
	}
}
