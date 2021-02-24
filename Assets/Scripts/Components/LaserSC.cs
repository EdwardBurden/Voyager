using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaserSC : ShipComponent, IWeapon
{
	public ShipComponent target;

	public int weaponAngle = 30;
	public int weaponRange = 5;

	public int damage;
	public float duration;
	public bool active;

	public bool CanActiveWeapon()
	{
		target = FindObjectsOfType<ShipCharacterController>().FirstOrDefault(x => x != characterController).GetAllComponents().FirstOrDefault(x => x is IDamageable) as ShipComponent;
		if (target == null)
		{
			return false;
		}
		float distance = Vector3.Distance(this.transform.position, target.transform.position);
		float angle = Vector3.Angle(this.transform.forward, target.transform.position - this.transform.position);
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

			Gizmos.color = Color.green;
			if (active)
			{
				Gizmos.DrawRay(this.transform.position, target.transform.position - this.transform.position);
			}
		}
	}

	public void ActiveWeapon()
	{

		active = true;
		target = FindObjectsOfType<ShipCharacterController>().FirstOrDefault(x => x != characterController).GetAllComponents().FirstOrDefault(x => x is IDamageable) as ShipComponent;
		StartCoroutine(FireLaser());

	}

	private IEnumerator FireLaser()
	{
		IDamageable damageable = target.GetComponent<IDamageable>();
		while (active && CanActiveWeapon())
		{
			yield return new WaitForSeconds(duration);
			damageable.DamageShipComponent(damage);
		}
		DeactiveWeapon();
	}

	public void DeactiveWeapon()
	{
		active = false;
		StopCoroutine(FireLaser());
	}
}
