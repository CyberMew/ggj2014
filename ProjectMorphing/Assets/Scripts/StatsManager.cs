using UnityEngine;
using System.Collections;
//using System.Net;
using System.Collections.Generic;

public class StatsManager : MonoBehaviour {

	private bool isOnline = true;
	//private bool isBusy = false;

	Dictionary<string, int> gameModesCounts = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
		//		StartCoroutine( AreWeConnectedToInternet() );
		gameModesCounts["Shooter"] = -1;
		gameModesCounts["Collectible"] = -1;
		gameModesCounts["Hybrid"] = -1;
		gameModesCounts["PureShooter"] = -1;
		gameModesCounts["PureCollectible"] = -1;
		gameModesCounts["PureHybrid"] = -1;
		// Get the updated result
		StartCoroutine( GetTotalPlaysForMode("Shooter") );
		StartCoroutine( GetTotalPlaysForMode("Collectible") );
		StartCoroutine( GetTotalPlaysForMode("Hybrid") );
		StartCoroutine( GetTotalPlaysForMode("PureShooter") );
		StartCoroutine( GetTotalPlaysForMode("PureCollectible") );
		StartCoroutine( GetTotalPlaysForMode("PureHybrid") );
	}
	
	// Update is called once per frame
	void Update () {
	/*if(Input.GetKeyDown(KeyCode.T))
		{
			Debug.Log(GetCurrentTotalModeStats(MODES.SHOOTER).ToString());
			Debug.Log(GetCurrentTotalModeStats(MODES.COLLECTIBLE).ToString());
		}*/
	}


	public enum MODES
	{
		SHOOTER,
		COLLECTIBLE,
		HYBRID,
		PURE_SHOOTER,
		PURE_COLLECTIBLE,
		PURE_HYBRID
	}

	public void SetIncrementGameModeStatsByOne(MODES mode)
	{
		if(isOnline == false)
		{
			Debug.Log("We are offline, unable to increment stats");
			// Revert to offline solution?
			return;
		}

		bool isOkay = false;
		string modes = "None";
		// Send score to server
		switch(mode)
		{
		case MODES.SHOOTER:
			modes = "Shooter";
			isOkay = true;
			break;
		case MODES.COLLECTIBLE:
			modes = "Collectible";
			isOkay = true;
			break;
		case MODES.HYBRID:
			modes = "Hybrid";
			isOkay = true;
			break;
		case MODES.PURE_SHOOTER:
			modes = "PureShooter";
			isOkay = true;
			break;
		case MODES.PURE_COLLECTIBLE:
			modes = "PureCollectible";
			isOkay = true;
			break;
		case MODES.PURE_HYBRID:
			modes = "PureHybrid";
			isOkay = true;
			break;
		}
		if(isOkay)
		{
			StartCoroutine( IncrementModeCount(modes) );
		}
	}

	public int GetCurrentTotalModeStats(MODES mode)
	{
		if(isOnline == false)
		{
			Debug.Log("We are offline, unable to retrieve stats");
			// Revert to offline solution?
			return -1;
		}
		
		//StartCoroutine( GetTotalPlaysForMode(mode) );
		
		string modes = "None";
		// Send score to server
		switch(mode)
		{
		case MODES.SHOOTER:
			modes = "Shooter";
			break;
		case MODES.COLLECTIBLE:
			modes = "Collectible";
			break;
		case MODES.HYBRID:
			modes = "Hybrid";
			break;
		case MODES.PURE_SHOOTER:
			modes = "PureShooter";
			break;
		case MODES.PURE_COLLECTIBLE:
			modes = "PureCollectible";
			break;
		case MODES.PURE_HYBRID:
			modes = "PureHybrid";
			break;
		}
		// Get the updated result
		StartCoroutine( GetTotalPlaysForMode(modes) );
		return gameModesCounts[modes];
	}
/*	public int GetCurrentTotalModeStats()
	{

	}

	// If we are still retrieving from server, then we are not done yet
	public bool CheckIsBusy()
	{
		return isBusy;
	}*/

	private string baseURL = "www.ahchao.me/ggj2014/";
	
	// remember to use StartCoroutine when calling this function!
	IEnumerator IncrementModeCount(string modes)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = Md5Sum(modes + secretKey);
		
		string post_url = baseURL + "increment.php?" + "mode=" + WWW.EscapeURL(modes);// + "&hash=" + hash;
		Debug.Log("IncrementModeCount post url: " + post_url);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			Debug.LogError("There was an error incrementing total mode count: " + hs_post.error);
		}

		Debug.Log("Posting to website: " + hs_post.text.TrimEnd());
	}

	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetTotalPlaysForMode(string modes)
	{
		string get_url = baseURL + "getmodes.php?" + "mode=" + WWW.EscapeURL(modes);

		WWW hs_get = new WWW(get_url);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the levels: " + hs_get.error);
		}
		else
		{
			Debug.Log("Updated " + modes + " score: " + int.Parse(hs_get.text));
			gameModesCounts[modes] = int.Parse(hs_get.text);
		}
	}

	/*
	private int GetTotalPlays(string modes)
	{
		string get_url = baseURL + "getmodes.php?" + "mode=" + WWW.EscapeURL(modes);
		
		WWW hs_get = new WWW(get_url);
		//yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the levels: " + hs_get.error);
			return -1;
		}
		else
		{
			return int.Parse(hs_get.text);
		}
	}*/
	/*
	WebAsync webAsync = new WebAsync();
	private IEnumerator AreWeConnectedToInternet () {
		WebRequest requestAnyURL = HttpWebRequest.Create(baseURL);
		requestAnyURL.Method = "HEAD";
		
		IEnumerator e = webAsync.GetResponse(requestAnyURL);
		while ( e.MoveNext() ) { yield return e.Current; }
		
		isServerAccessible = (webAsync.requestState.errorMessage == null);
		
		Debug.Log("Are we connected to the inter webs? " + isServerAccessible);
		if(isServerAccessible)
		{
			isOnline = true;
			//StartCoroutine( GetLevels() );
		}
	}*/

}
