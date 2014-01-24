using UnityEngine;
using System.Collections;

public class ModePicker : MonoBehaviour 
{
	private int shooter, collector, total;
	private HybridManager hybridManager;
	private ShooterManager shooterManager;
	private CollectorManager collectorManager;

	void ActivateHybrid()
	{
		GameObject hybridManagerObject = GameObject.FindWithTag("HybridManager");
		if(hybridManagerObject)
		{
			hybridManager = hybridManagerObject.GetComponent<HybridManager>();
		}
		else
		{
			Debug.Log("Cannot find mode Hybrid Manager!");
		}

		hybridManager.Activate();
	}

	void ActivateShooter()
	{
		GameObject shooterManagerObject = GameObject.FindWithTag("ShooterManager");
		if(shooterManagerObject)
		{
			shooterManager = shooterManagerObject.GetComponent<ShooterManager>();
		}
		else
		{
			Debug.Log("Cannot find mode Shooter Manager!");
		}

		shooterManager.Activate();
	}

	void ActivateCollector()
	{
		GameObject collectorManagerObject = GameObject.FindWithTag("CollectorManager");
		if(collectorManagerObject)
		{
			collectorManager = collectorManagerObject.GetComponent<CollectorManager>();
		}
		else
		{
			Debug.Log("Cannot find mode Hybrid Manager!");
		}

		collectorManager.Activate();
	}

	void Update()
	{
		switch(total)
		{
			case 0:
			{
				break;
			}
			case 1:
			{
//				// start shooter
//				if(shooter == total)
//				{
//					
//				}
//				// start collector
//				else // collector == total
//				{
//					
//				}
				break;
			}
			case 2:
			{
				// start hybrid
				if(shooter == collector)
				{
					ActivateHybrid();
				}
				// start shooter
				else if(shooter == total)
				{
					ActivateShooter();
				}
				// start collector
				else
				{
					ActivateCollector();
				}
				break;
			}
			default:
			{
				Debug.Log("Add new cases!");
				break;
			}
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
