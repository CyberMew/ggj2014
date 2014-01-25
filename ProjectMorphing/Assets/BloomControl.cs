using UnityEngine;
using System.Collections;

public class BloomControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		var m_ModePicker = (ModePicker)GameObject.FindObjectOfType(typeof(ModePicker)) as ModePicker;
		if(m_ModePicker == null) 
			return;
		
		switch(m_ModePicker.GetComponent<ModePicker>().GetGameMode())
		{
		case ModePicker.GAME_MODE.IDLE:
			gameObject.GetComponent<Bloom>().SkyColor = Color.cyan;
			break;
			
			
		case ModePicker.GAME_MODE.SHOOTER:
			gameObject.GetComponent<Bloom>().SkyColor = Color.green;
			break;
			
		case ModePicker.GAME_MODE.COLLECTOR:
			gameObject.GetComponent<Bloom>().SkyColor = Color.grey;
			break;
			
		case ModePicker.GAME_MODE.HYBIRD:
			gameObject.GetComponent<Bloom>().SkyColor = Color.red;
			break;
			
		}
		
		
	}




}
