using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatingSC : ShipComponent, IDamageable
{
	public ShipComponentDamageStates[] damageStates;
	private int damageStateIndex;

	public float explosiveForce = 10;
	public float explosiveRadius = 10;
	public float maxComponentHealth = 100;
	private float componentHealth;

	private float healthPercentage => componentHealth / maxComponentHealth;

	private void Awake()
	{
		componentHealth = maxComponentHealth;
		damageStateIndex = 0;
	}

	public void DamageShipComponent(float dmg)
	{
		componentHealth -= dmg;
		UpdateDamageState();
		if (componentHealth <= 0)
		{
			DestroyComponent();
		}
	}

	public void DestroyComponent()
	{
		shipControl.RemoveComponent(this);
		Debug.Log(name);
		float x = Random.Range(-1.0f, 1.0f) * explosiveForce;
		float y = Random.Range(-1.0f, 1.0f) * explosiveForce;
		float z = Random.Range(-1.0f, 1.0f) * explosiveForce;
		shipRigidbody.AddForce(new Vector3(x, y, z), ForceMode.Impulse);
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, explosiveRadius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(explosiveForce, explosionPos, explosiveRadius, 3.0F);
		}
	}

	public void UpdateDamageState()
	{
		int index = 0;
		while (index < damageStates.Length - 1 && healthPercentage < damageStates[index].healthThreshold)
		{
			index++;
		}
		if (damageStateIndex != index)
		{
			damageStateIndex = index;
			shipRenderer.material = damageStates[damageStateIndex].material;
		}

	}
}
