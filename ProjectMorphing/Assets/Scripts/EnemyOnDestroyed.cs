using UnityEngine;
using System.Collections;

public class EnemyOnDestroyed : MonoBehaviour {

	public GameObject audioSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		Instantiate(audioSource, new Vector3(), Quaternion.identity);
	}
}
