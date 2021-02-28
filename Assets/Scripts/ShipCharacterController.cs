using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ShipCharacterController : MonoBehaviour
{
	private ShipConstructor constructor;
	private Rigidbody rigidbody => GetComponent<Rigidbody>();

	public bool inputAccelerate = false;
	public bool inputReverse = false;
	public Vector2 inputDirection;

	private float hitDamage = 10;
	public float[] speeds = new float[] { 0, 1, 2, 3 };
	public float reverseSpeed; //do later
	public int speedIndex = 0;

	private float accelerationPerUpdate = 0.1f;

	public LayerMask componentLayer;

	internal void SetComponentsToBuild()
	{
		foreach (ShipComponent shipComponent in constructor.connectedComponents)
		{
			shipComponent.OnBuild();
		}
	}

	internal void SetComponentsToFlight()
	{
		foreach (ShipComponent shipComponent in constructor.connectedComponents)
		{
			shipComponent.OnFlight();
		}
	}

	public void Init()
	{
		this.constructor = new ShipConstructor(this);
	}

	public void ConstructShip(List<ShipComponent> components)
	{
		constructor.ContrustShip(components);
	}

	public void ConstructShip()
	{
		constructor.ContrustShip();
	}

	public void Rotate(int rotationAmount)
	{
		Vector3 eulerAngles = this.rigidbody.rotation.eulerAngles;
		Quaternion angles = Quaternion.Euler(eulerAngles.x, eulerAngles.y + rotationAmount, eulerAngles.z);
		rigidbody.MoveRotation(angles);
	}

	public void Addcomponent(ShipComponent shipComponent)
	{
		constructor.AddComponent(shipComponent);
	}

	internal IEnumerable<ShipComponent> GetAllComponents()
	{
		return constructor.connectedComponents;
	}

	public void RemoveComponent(ShipComponent shipComponent)
	{
		constructor.RemoveComponent(shipComponent);
	}

	private void FixedUpdate()
	{
		//Fixed_HandleMovement();
		//	Fixed_HandleRotation();
		rigidbody.velocity = transform.forward * speeds[speedIndex];
	}

	private void Fixed_HandleMovement()
	{
		if (inputAccelerate)
		{
			Fixed_Accelerate();
		}
		if (inputReverse)
		{
			Fixed_Reverse();
		}
		if (!inputAccelerate && !inputReverse)
		{
			if (rigidbody.velocity.magnitude > 0.1f)
			{
				Fixed_Rest();
			}
			else
			{
				rigidbody.velocity = Vector3.zero;
			}
		}
	}

	private void Fixed_HandleRotation()
	{
		Vector3 direction = new Vector3(inputDirection.x, 0, inputDirection.y);
		rigidbody.rotation = (Quaternion.LookRotation(direction).normalized);
	}

	public void IncreaseSpeed()
	{
		if (speedIndex >= speeds.Length - 1)
		{
			return;
		}
		speedIndex++;
	}

	public void DecreaseSpeed()
	{
		if (speedIndex <= 0)
		{
			return;
		}
		speedIndex--;
	}

	public void Rest()
	{
		speedIndex = 0;
	}

	private void Fixed_Accelerate()
	{
		if (rigidbody.velocity.magnitude <= speeds[speedIndex])
		{
			rigidbody.velocity += transform.forward * accelerationPerUpdate;
		}
	}

	private void Fixed_Rest()
	{
		rigidbody.velocity += (Vector3.zero - (rigidbody.velocity * accelerationPerUpdate));
		rigidbody.angularVelocity += (Vector3.zero - (rigidbody.angularVelocity * accelerationPerUpdate));
	}

	private void Fixed_Reverse()
	{
		rigidbody.velocity += -transform.forward * accelerationPerUpdate;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 normalSum = Vector3.zero;
		for (int i = 0; i < collision.contacts.Length; i++)
		{
			normalSum += collision.GetContact(i).normal;
		}
		normalSum.Normalize();

		float collisionAngle = Vector3.Angle(collision.relativeVelocity.normalized, normalSum);
		float angle = Mathf.Deg2Rad * collisionAngle;
		float damage = hitDamage * (1 - Mathf.Sin(angle));
		foreach (GameObject contact in collision.contacts.Select(x => x.thisCollider.gameObject).Distinct())
		{
			IDamageable damageable = contact.GetComponentInParent<IDamageable>();
			if (damageable != null)
			{
				damageable.DamageShipComponent(damage);
			}
		}

	}

}

