using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 2f);
	}
}
