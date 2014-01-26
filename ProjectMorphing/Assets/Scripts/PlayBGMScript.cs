using UnityEngine;
using System.Collections;

public class PlayBGMScript : MonoBehaviour {
	public AudioClip bgm;
	// Use this for initialization
	void Start () {
		audio.PlayOneShot(bgm, 0.7F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
