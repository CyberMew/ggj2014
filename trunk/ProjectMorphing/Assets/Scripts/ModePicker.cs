using UnityEngine;
using System.Collections;

public class ModePicker : MonoBehaviour 
{




	public enum GAME_MODE
	{
		IDLE,
		SHOOTER,
		COLLECTOR,
		HYBIRD
	}
	public GAME_MODE m_GameMode = GAME_MODE.IDLE;


	private int shooter, collector, total;
	public GameObject hybridSpawnManager, collectorSpawnManager, shooterSpawnManager;
	private Vector3 vec3 = new Vector3();
	private Quaternion quat = new Quaternion();
//	private HybridManager hybridManager;
//	private ShooterManager shooterManager;
//	private CollectorManager collectorManager;
//
//	void ActivateHybrid()
//	{
//		GameObject hybridManagerObject = GameObject.FindWithTag("HybridManager");
//		if(hybridManagerObject)
//		{
//			hybridManager = hybridManagerObject.GetComponent<HybridManager>();
//		}
//		else
//		{
//			Debug.Log("Cannot find Hybrid Manager!");
//		}
//
//		hybridManager.Activate();
//	}
//
//	void ActivateShooter()
//	{
//		GameObject shooterManagerObject = GameObject.FindWithTag("ShooterManager");
//		if(shooterManagerObject)
//		{
//			shooterManager = shooterManagerObject.GetComponent<ShooterManager>();
//		}
//		else
//		{
//			Debug.Log("Cannot find Shooter Manager!");
//		}
//
//		shooterManager.Activate();
//	}
//
//	void ActivateCollector()
//	{
//		GameObject collectorManagerObject = GameObject.FindWithTag("CollectorManager");
//		if(collectorManagerObject)
//		{
//			collectorManager = collectorManagerObject.GetComponent<CollectorManager>();
//		}
//		else
//		{
//			Debug.Log("Cannot find Hybrid Manager!");
//		}
//
//		collectorManager.Activate();
//	}

	void CreateHybrid()
	{
		Instantiate(hybridSpawnManager, vec3, quat);
	}
	void CreateShooter()
	{
		Instantiate(shooterSpawnManager, vec3, quat);
	}
	void CreateCollector()
	{
		Instantiate(collectorSpawnManager, vec3, quat);
	}
	void Update()
	{

		if(Input.GetKeyDown(KeyCode.T))
		{ 
			++m_GameMode;
			if(m_GameMode == GAME_MODE.HYBIRD+1)
				m_GameMode = GAME_MODE.IDLE;
		}
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
					CreateHybrid();
					m_GameMode = GAME_MODE.HYBIRD;
				}
				// start shooter
				else if(shooter == total)
				{
					CreateShooter();
					m_GameMode = GAME_MODE.SHOOTER;
				}
				// start collector
				else
				{
					CreateCollector();
					m_GameMode = GAME_MODE.COLLECTOR;
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

	public GAME_MODE GetGameMode() {return m_GameMode;}
	public void SetGameMode( GAME_MODE m) { m_GameMode = m; }


}
