using UnityEngine;
using System.Collections;

public class TimedPhasing : MonoBehaviour 
{
	private SpriteRenderer spriteRenderer;
	private float alpha = 0.0f;
	public float phaseInWaitTimer;
	private float myPhaseInWaitTimer;
	public float fadeInTimeInSeconds;
	private float fadeInDelta;
	public float phaseOutWaitTimer;
	private float myPhaseOutWaitTimer;
	public float fadeOutTimeInSeconds;
	private float fadeOutDelta;
	private bool fadeIn = true;
	private bool fadeOut = false;
	private bool isCollectable = false;
	public float collectableThreshHold;

	public bool CanCollect()
	{
		return isCollectable;
	}

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer)
		{
			spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
		}
		else
		{
			Debug.Log("TimedPhasing | Start | spriteRenderer not found!");
		}
		fadeInDelta = 1.0f / (fadeInTimeInSeconds / Time.fixedDeltaTime);
		fadeOutDelta = -1.0f / (fadeOutTimeInSeconds / Time.fixedDeltaTime);
		myPhaseInWaitTimer = phaseInWaitTimer;
		myPhaseOutWaitTimer = phaseOutWaitTimer;
	}

	IEnumerator PhasingIn()
	{
		yield return new WaitForSeconds(myPhaseInWaitTimer);
		//myPhaseInWaitTimer = 0.0f;

		if(spriteRenderer)
		{
			if(spriteRenderer.color.a > collectableThreshHold)
			{
				isCollectable = true;
			}
			if(spriteRenderer.color.a < 1.0f)
			{
				alpha += fadeInDelta;
				spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
			}
			else
			{
				spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
				fadeIn = false;
				myPhaseInWaitTimer = phaseInWaitTimer;
				fadeOut = true;
			}
		}
		else
		{
			Debug.Log("TimedPhasing | Start | spriteRenderer not found!");
		}
		yield return new WaitForSeconds(0f);
	}

	IEnumerator PhasingOut()
	{
		//Debug.Log("PhaseOut called");
		yield return new WaitForSeconds(myPhaseOutWaitTimer);
		//myPhaseOutWaitTimer = 0.0f;
		//Debug.Log("PhaseOut done waiting");

		if(spriteRenderer)
		{
			if(spriteRenderer.color.a < collectableThreshHold)
			{
				isCollectable = false;
			}
			if(spriteRenderer.color.a > 0.0f)
			{
				alpha += fadeOutDelta;
				spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
			}
			else
			{
				spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
				fadeOut = false;	
				myPhaseOutWaitTimer = phaseOutWaitTimer;
				fadeIn = true;
				alpha = 0f;
			}
		}
		else
		{
			Debug.Log("TimedPhasing | Start | spriteRenderer not found!");
		}

		yield return new WaitForSeconds(0f);
	}

	public void TriggerPhaseOut()
	{
		fadeOut = true;
		fadeIn = false;
		myPhaseOutWaitTimer = 0f;
		StopCoroutine("PhasingIn");
	}

	void Update()
	{
		if(fadeIn)
		{
			StartCoroutine("PhasingIn");
		}
		else if(fadeOut)
		{
			StartCoroutine(PhasingOut());
		}
	}
}
