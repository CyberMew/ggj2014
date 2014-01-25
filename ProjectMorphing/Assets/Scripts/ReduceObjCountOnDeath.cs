using UnityEngine;
using System.Collections;

public class ReduceObjCountOnDeath : MonoBehaviour 
{
	private WinLoseManagerScript winLoseManager;

	void OnDestroy()
	{
		GameObject winLoseManagerObject = GameObject.FindGameObjectWithTag("WinLoseManager");
		if(winLoseManagerObject)
		{
			winLoseManager = winLoseManagerObject.GetComponent<WinLoseManagerScript>();
			if(winLoseManager)
			{
				winLoseManager.ReduceObjectCount();
			}
		}
	}

}
