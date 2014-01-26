using UnityEngine;
using System.Collections;

public class PlaySoundScript : MonoBehaviour {

	public AudioClip sfx;
	// Use this for initialization
	void Start () {
		
		audio.PlayOneShot(sfx, 0.7F);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
