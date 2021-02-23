using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSC : ShipComponent, IWeapon
{
	public ShipComponent target;

	public int weaponAngle = 30;
	public int weaponRange = 5;

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

	public void CanActiveWeapon()
	{
		throw new System.NotImplementedException();
	}

	public bool CanHit()
	{
		float distance = Vector3.Distance(this.transform.position, target.transform.position);
		float angle = Vector2.Angle(this.transform.forward, target.transform.position - this.transform.position);
		return angle < weaponAngle && distance < weaponRange;
	}

	private void OnDrawGizmos()
	{
		if (target != null)
		{
			Vector3 maxX = Quaternion.AngleAxis(weaponAngle, transform.up) * transform.forward * weaponRange;
			Vector3 minX = Quaternion.AngleAxis(-weaponAngle, transform.up) * transform.forward * weaponRange;


			Gizmos.color = Color.blue;
			Gizmos.DrawRay(this.transform.position, maxX.normalized * weaponRange);
			Gizmos.DrawRay(this.transform.position, minX.normalized * weaponRange);

			Vector3 maxY = Quaternion.AngleAxis(weaponAngle, transform.right) * transform.forward * weaponRange;
			Vector3 minY = Quaternion.AngleAxis(-weaponAngle, transform.right) * transform.forward * weaponRange;


			Gizmos.color = Color.blue;
			Gizmos.DrawRay(this.transform.position, maxY.normalized * weaponRange);
			Gizmos.DrawRay(this.transform.position, minY.normalized * weaponRange);
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
			//damageable.DamageShipComponent(damage);
		}
	}

	public void DeactiveWeapon()
	{
		active = false;
		StopCoroutine(FireLaser());
	}
}
