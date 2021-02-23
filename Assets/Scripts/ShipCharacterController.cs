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
	private float accelerationPerUpdate = 0.1f;

	public LayerMask componentLayer;
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
		Fixed_HandleMovement();
		Fixed_HandleRotation();
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

	private void Fixed_Accelerate()
	{
		rigidbody.velocity += transform.forward * accelerationPerUpdate;
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

