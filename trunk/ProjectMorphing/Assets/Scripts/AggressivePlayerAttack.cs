using UnityEngine;
using System.Collections;

public class AggressivePlayerAttack : MonoBehaviour {

	public float baseCooldown = 0.1f;
	public float cooldownBuffModifier = 1f;
	public float cooldownUpgradeModifier = 1f;

	private bool canAttack = true;
	public GameObject bulletObject = null;
	public float bulletFrontOffset = 0.5f;

	public float baseBulletSpeed = 0.15f;

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
		
		// else if above checks fail, we just do range attack
		Vector4 vec = (transform.localToWorldMatrix * new Vector4(bulletFrontOffset, 0f, 0f, 0f));
		GameObject myBullet = Instantiate(bulletObject, transform.position + new Vector3(vec.x, vec.y, vec.z), transform.rotation) as GameObject;

		FlyForward flyForwardComp = myBullet.GetComponent<FlyForward>();
		if(flyForwardComp)
		{
			flyForwardComp.shootingVector = new Vector3(baseBulletSpeed * cooldownBuffModifier * cooldownUpgradeModifier, 0f, 0f);
		}
  }
  
  void resetCanAttack()
  {
	canAttack = true;
  }
}
