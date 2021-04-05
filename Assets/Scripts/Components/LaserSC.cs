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

	public GameObject laserHead;
	public Transform laserSpawn;
	public LineRenderer lineRenderer;

	public float laserActivationTime;

	private void Awake()
	{
		lineRenderer.gameObject.SetActive(false);
	}

	//FUTURE ED!!!!!!!, PUT ALL THIS BEHAVIOUR IN THE DEFINITION, AND PASS IN ANY FACTORS LIKE CURRENT COMPONENT DAMAGE OR EFFECTS THT AFFEXCT THE BEHAVIOUR, OKAY LOVE U BYE

	private void Update()
	{
		if (active)
		{
			if (!CanActiveWeapon())
			{
				DeactiveWeapon();
				//move damage ghere
			}
			else
			{
				IDamageable damageable = target.GetComponent<IDamageable>();
				damageable.DamageShipComponent(damage * Time.deltaTime);
			}
		}
	}

	public bool CanActiveWeapon()
	{
		target = FindObjectsOfType<ShipCharacterController>().FirstOrDefault(x => x != characterController).connectedComponents.FirstOrDefault(x => x is IDamageable) as ShipComponent;
		if (target == null)
		{
			return false;
		}
		float distance = Vector3.Distance(this.transform.position, target.transform.position);
		float angle = Vector3.Angle(this.transform.forward, target.transform.position - this.transform.position);
		return angle < weaponAngle && distance < weaponRange;
	}



	/*private void OnDrawGizmos()
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
	*/

	public void ActiveWeapon()
	{
		active = true; //move to end of extend laser
		target = FindObjectsOfType<ShipCharacterController>().FirstOrDefault(x => x != characterController).connectedComponents.FirstOrDefault(x => x is IDamageable) as ShipComponent;
		lineRenderer.gameObject.SetActive(true);
		//StartCoroutine(FireLaser());
		StartCoroutine(MoveLaserHead());
		StartCoroutine(ExtendLaserTrace());
	}

	private IEnumerator MoveLaserHead()
	{
		while (true)
		{
			laserHead.transform.LookAt(target.transform.position, transform.up);
			lineRenderer.SetPosition(0, laserSpawn.position);
			lineRenderer.SetPosition(1, target.transform.position);
			yield return null;
		}
	}

	private IEnumerator ExtendLaserTrace()
	{
		float timer = 0;
		while (timer < laserActivationTime)
		{
			float range = timer / laserActivationTime;
			float distance = Vector3.Distance(target.transform.position, laserSpawn.position);
			lineRenderer.SetPosition(0, laserSpawn.position);
			lineRenderer.SetPosition(1, laserSpawn.position + ((target.transform.position - laserSpawn.position) * range));
			timer += Time.deltaTime;
			yield return null;
		}
		active = true;
	}

	public void DeactiveWeapon()
	{
		active = false;
		laserHead.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);
		StopAllCoroutines();
		lineRenderer.gameObject.SetActive(false);
	}

	public int GetPowerRequired()
	{
		return 10;
	}
}
