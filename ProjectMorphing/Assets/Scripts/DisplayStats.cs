using UnityEngine;
using System.Collections;

public class DisplayStats : MonoBehaviour {

	private StatsManager stats;
	private int shooterPlays = 0;
	private int collectiblePlays = 0;
	private int hybridPlays = 0;
	
	private int shooterPlaysCached = 0;
	private int collectiblePlaysCached = 0;
	private int hybridPlaysCached = 0;

	float startTime = 0f;

	// Use this for initialization
	void Start () {
		//stats = this.gameObject.AddComponent<StatsManager>();//new StatsManager();
		
	//	collectiblePlaysCached = stats.GetCurrentTotalModeStats(StatsManager.MODES.COLLECTIBLE);
	//	shooterPlaysCached = stats.GetCurrentTotalModeStats(StatsManager.MODES.SHOOTER);
		//hybridPlaysCached = stats.GetCurrentTotalModeStats(StatsManager.MODES.HYBRID);

		collectiblePlaysCached = 500;
		hybridPlaysCached = 500;
		shooterPlaysCached = 500;
		//stats.SetIncrementGameModeStatsByOne(StatsManager.MODES.COLLECTIBLE);

		startTime = Time.realtimeSinceStartup;
	}

	void OnEnable()
	{
	//	stats = this.gameObject.AddComponent<StatsManager>();
		stats = GameObject.Find("StatsManager").GetComponent<StatsManager>();

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
		// Animate the numbers
		/*if(shooterPlays < shooterPlaysCached)
		{
			shooterPlays = (int)((float)shooterPlays * 1.2f);
		}
		else
		{
			shooterPlays = shooterPlaysCached;
		}
		if(collectiblePlays < collectiblePlaysCached)
		{
				collectiblePlays = (int)(collectiblePlays * 1.2f);
		}
		else
		{
			collectiblePlays = collectiblePlaysCached;
		}
		if(hybridPlays < hybridPlaysCached)
		{
					hybridPlays = (int)(hybridPlays * 1.2f);
		}
		else
		{
			hybridPlays = hybridPlaysCached;
		}*/
		shooterPlays = (int) Mathf.Lerp(0f, shooterPlaysCached, (Time.realtimeSinceStartup - startTime) / 1f);
		collectiblePlays = (int) Mathf.Lerp(0f, collectiblePlaysCached, (Time.realtimeSinceStartup - startTime) / 2f);
		hybridPlays = (int) Mathf.Lerp(0f, hybridPlaysCached, (Time.realtimeSinceStartup - startTime) / 3f);
	}

	void OnGUI()
	{
		// Backup the current matrix
		Matrix4x4 oldMtx = GUI.matrix;
		// Applying the matrix so that the buttons will scale in position and size accordingly to screen
		float centerX = Screen.width * 0.5f;
		GUIUtility.ScaleAroundPivot(new Vector2(Screen.width/MySystem.sWIDTH, Screen.height/MySystem.sHEIGHT), new Vector2(0f, 0f));

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
