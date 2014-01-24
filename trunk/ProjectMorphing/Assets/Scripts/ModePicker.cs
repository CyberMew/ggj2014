using UnityEngine;
using System.Collections;

public class ModePicker : MonoBehaviour 
{
	private int shooter, collector, total;

	void Update()
	{
		if(total == 2)
		{

		}
	}

	public void AddToShooter()
	{
		++shooter;
		++total;
	}

	public void AddToCollector()
	{
		++collector;
		++total;
	}
}
