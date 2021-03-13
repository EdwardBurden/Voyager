using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ShipCharacterController : MonoBehaviour , ISelectable
{
	public ControlSC control => connectedComponents.FirstOrDefault(x => x is ControlSC) as ControlSC;
	public List<ShipComponent> connectedComponents;
	private Rigidbody rigidbody => GetComponent<Rigidbody>();

	//Movement
	private Quaternion targetDirection = Quaternion.identity;
	private int rotationSpeed = 10;

	private float[] maxSpeeds = new float[] { -1, 0, 1, 2, 3 };
	private int maxSpeedIndex = 1;
	private float speedModifier = 3;

	private float accelerationPerUpdate = 0.1f;
	private float speedChangeTimer = 0;

	private float hitDamage = 10;


	public void Init()
	{
		targetDirection = rigidbody.rotation;
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

	public void Rotate(int rotationAmount)
	{
		Vector3 eulerAngles = this.rigidbody.rotation.eulerAngles;
		targetDirection = Quaternion.Euler(0, eulerAngles.y + rotationAmount, 0);
	}

	public void IncreaseSpeed()
	{
		if (maxSpeedIndex >= maxSpeeds.Length - 1)
		{
			return;
		}
		maxSpeedIndex++;
		speedChangeTimer = 0;
	}

	public void DecreaseSpeed()
	{
		if (maxSpeedIndex <= 0)
		{
			return;
		}
		maxSpeedIndex--;
		speedChangeTimer = 0;
	}

	public void Rest()
	{
		maxSpeedIndex = 1;
		speedChangeTimer = 0;
	}

	private void FixedUpdate()
	{
		rigidbody.centerOfMass = control.transform.position;
		Fixed_HandleMovement();
		Fixed_Accelerate();
		Fixed_HandleRotation();
	}

	private void Fixed_HandleMovement()
	{
		if (rigidbody.position.y != 0)
		{
			rigidbody.position += (new Vector3(rigidbody.position.x, 0, rigidbody.position.z) - rigidbody.position) * accelerationPerUpdate; //could freeze position
		}    
		rigidbody.angularVelocity += (Vector3.zero - (rigidbody.angularVelocity * accelerationPerUpdate));
	}

	private void Fixed_HandleRotation()
	{
		if (targetDirection == rigidbody.rotation)
		{
			return;
		}
		rigidbody.rotation = Quaternion.Lerp(rigidbody.rotation, targetDirection, Time.deltaTime * rotationSpeed);
	}

	private void Fixed_Accelerate()
	{
		if (maxSpeedIndex == 1 && rigidbody.velocity.magnitude == 0)
		{
			return;
		}
		speedChangeTimer = Mathf.Min(speedChangeTimer + accelerationPerUpdate, 1);
		float targetSpeed = maxSpeeds[maxSpeedIndex] * speedModifier;
		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.forward * targetSpeed, speedChangeTimer);
	}
}

