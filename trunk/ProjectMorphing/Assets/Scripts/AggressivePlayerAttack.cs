using UnityEngine;
using System.Collections;

public class AggressivePlayerAttack : MonoBehaviour {

	public float baseCooldown = 0.1f;
	public float cooldownBuffModifier = 1f;
	public float cooldownUpgradeModifier = 1f;

	private bool canAttack = true;
	public GameObject bulletObject = null;
	public float bulletFrontOffset = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("Fire"))
		{
			Attack();
		}
	}

	void Attack()
	{
		if(canAttack)
		{
			canAttack = false;
			Invoke("resetCanAttack", baseCooldown * cooldownBuffModifier * cooldownUpgradeModifier);
			DealDamage();
		}
	}

	void DealDamage()
	{
		int childCount = transform.childCount;
		
		if(childCount > 0)
		{
			Transform childTransform = transform.GetChild(0);
			AggressiveMelee aggroMeleeComp = childTransform.GetComponent<AggressiveMelee>();
			
			if(aggroMeleeComp)
			{
				if(aggroMeleeComp.Attack())
				{
					// NOTE: DANGER CODE, RETURNING STRAIGHT
					return;
				}
			}
		}
		
		// else if any condition fails we just do range attack
		Vector4 vec = (transform.localToWorldMatrix * new Vector4(bulletFrontOffset, 0f, 0f, 0f));
		Instantiate(bulletObject, transform.position + new Vector3(vec.x, vec.y, vec.z), Quaternion.identity);
  }
  
  void resetCanAttack()
  {
	canAttack = true;
  }
}
