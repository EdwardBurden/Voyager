using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSC : ShipComponent
{
	public ShipComponent target;
	public Vector2 angle = new Vector2(50, 20);
	public int range = 5
	public int damage;
	public float duration;
	public bool active;


	private void Update()
	{
		if (active)
		{
			if (!CanHit())
			{
				DeactiveWeapon();
			}
		}
	}

	public bool CanHit()
	{
		Vector2 forwardDirection = new Vector2(this.transform.forward.x, this.transform.forward.z);
		Vector2 targetDirection = new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.z - this.transform.position.z);
		float XZAxis = Vector2.Angle(targetDirection, forwardDirection);
		//to do 

		return  XZAxis < angle.x;
	}

	private void OnDrawGizmos()
	{
		if (target != null)
		{
			Vector2 forwardDirection = new Vector2(this.transform.forward.x + this.transform.position.x, this.transform.forward.z + this.transform.position.z);
			Gizmos.DrawLine(new Vector3(forwardDirection.x, this.transform.position.y, forwardDirection.y), this.transform.position);

			Vector2 targetDirection = new Vector2(target.transform.position.x, target.transform.position.z);
			Gizmos.DrawLine(new Vector3(targetDirection.x, this.transform.position.y, targetDirection.y), this.transform.position);

		}
	}

	public void ActiveWeapon()
	{
		active = true;
		StartCoroutine(FireLaser());

	}


	private IEnumerator FireLaser()
	{
		IDamageable damageable = target.GetComponent<IDamageable>();
		while (active)
		{
			yield return new WaitForSeconds(duration);
			damageable.DamageShipComponent(damage);
		}
	}

	public void DeactiveWeapon()
	{
		active = false;
		StopCoroutine(FireLaser());
	}

}
