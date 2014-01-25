using UnityEngine;
using System.Collections;

public class BasicCollectorScript : MonoBehaviour 
{
	// this is the basic collect script.
	// all collectibles will have this script
	// which will call the body's add segment code
	private TimedPhasing timedPhasingComponent;

	void OnTriggerEnter2D(Collider2D other)
	{
		timedPhasingComponent = GetComponent<TimedPhasing>();

		if(other.tag == "Player")
		{
			if(timedPhasingComponent)
			{
				if(timedPhasingComponent.CanCollect())
				{
					Destroy(gameObject);
					//other.gameObject.AddSegment();
				}
				else
				{
					timedPhasingComponent.TriggerPhaseOut();
				}
			}
			else
			{
					Destroy(gameObject);
					//other.gameObject.AddSegment();
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		timedPhasingComponent = GetComponent<TimedPhasing>();
		
		if(other.tag == "Player")
		{
			if(timedPhasingComponent)
			{
				if(!timedPhasingComponent.CanCollect())
				{
					timedPhasingComponent.TriggerPhaseOut();
				}
			}
		}
	}
}
