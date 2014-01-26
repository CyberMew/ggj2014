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
	public int shooter, collector, total;
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
	
	public Vector3 dittoPos1 = new Vector3(-3, 2f, 0f);
	public Vector3 dittoPos2 = new Vector3(3f, 2f, 0f);
	public Vector3 playerPos = new Vector3(0f, -2f, 0f);
	public GameObject dittoObject;
	public GameObject aggresivePlayer;
	public GameObject collectorPlayer;
	public GameObject hybridPlayer;
	//private GameObject currentPlayer;
	private bool modeChosen = false;
	private bool modeChosen2 = false;
	public GameObject initialPlayer;
	private GameObject currPlayer;

	private StatsManager stats;
	
	void Start()
	{
		//		currentPlayer = GameObject.FindGameObjectWithTag("Player");
		//		if(!currentPlayer)
		//		{
		//			Debug.Log ("Player can't be found!");
		//		}
		stats = GameObject.Find("StatsManager").GetComponent<StatsManager>();

		currPlayer = Instantiate(initialPlayer, playerPos, Quaternion.identity) as GameObject;
		Instantiate(dittoObject, dittoPos1, Quaternion.identity);
		Instantiate(dittoObject, dittoPos2, Quaternion.identity);

	}
	
	void CreateHybrid()
	{
		Instantiate(hybridPlayer, currPlayer.transform.position, currPlayer.transform.rotation);
		Destroy(currPlayer);
		Instantiate(hybridSpawnManager, vec3, quat);
		stats.SetIncrementGameModeStatsByOne (StatsManager.MODES.HYBRID);
	}
	void CreateShooter()
	{
		Instantiate(aggresivePlayer, currPlayer.transform.position, currPlayer.transform.rotation);
		Destroy(currPlayer);
		Instantiate(shooterSpawnManager, vec3, quat);
		stats.SetIncrementGameModeStatsByOne(StatsManager.MODES.SHOOTER);
	}
	void CreateCollector()
	{
		Instantiate(collectorPlayer, currPlayer.transform.position, currPlayer.transform.rotation);
		Destroy(currPlayer);
		Instantiate(collectorSpawnManager, vec3, quat);
		stats.SetIncrementGameModeStatsByOne (StatsManager.MODES.COLLECTIBLE);
	}
	void Update()
	{
		if(modeChosen)
		{
			return;
		}

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
				modeChosen = true;
				CreateHybrid();
				m_GameMode = GAME_MODE.HYBIRD;
			}
			// start shooter
			else if(shooter == total)
			{
				modeChosen = true;
				CreateShooter();
				m_GameMode = GAME_MODE.SHOOTER;
			}
			// start collector
			else
			{
				modeChosen = true;
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

		Debug.Log ("shooter: " + shooter +"\ncollector: " + collector + "\ntotal: " + total);
	}
	
	public void AddToCollector()
	{		
		++collector;
		++total;

		Debug.Log ("shooter: " + shooter +"\ncollector: " + collector + "\ntotal: " + total);
	}
	
	public GAME_MODE GetGameMode() {return m_GameMode;}
	public void SetGameMode( GAME_MODE m) { m_GameMode = m; }
	
	
}
