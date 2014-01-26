using UnityEngine;
using System.Collections;

public class ExplosionOnDestruction : MonoBehaviour {
	public GameObject explosionObj = new GameObject();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		Instantiate(explosionObj, transform.position, Quaternion.identity);
	}
}
