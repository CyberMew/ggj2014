using UnityEngine;
using System.Collections;

public class DittoContact : MonoBehaviour 
{
	private ModePicker modePicker;

	void Start()
	{
		GameObject modePickerObject = GameObject.FindWithTag("ModeLogicPicker");
		if(modePickerObject)
		{
			modePicker = modePickerObject.GetComponent<ModePicker>();
		}
		else
		{
			Debug.Log("Cannot find mode logic picker!");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			// add to collect mode
			modePicker.AddToCollector();
		}
		else if(other.tag == "PlayerProjectile")
		{
			// add to projectile mode
			modePicker.AddToShooter();
		}
	}
}
