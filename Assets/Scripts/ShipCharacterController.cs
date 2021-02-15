using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ShipCharacterController : MonoBehaviour
{
	[SerializeField]
	private PlayerInput shipInput;

	private Rigidbody rigidbody => GetComponent<Rigidbody>();

	private bool inputAccelerate = false;
	private bool inputReverse = false;

	private Vector2 inputDirection;

	private float maxvelocity;
	private float accelerationPerUpdate = 0.1f;


	public void SwitchToBuild(CallbackContext value)
	{
		if (value.started)
		{
			shipInput.SwitchCurrentActionMap("Build");
			GameManager.SwitchToBuildMode();
		}
	}

	public void SwitchToFlight(CallbackContext value)
	{
		if (value.started)
		{
			shipInput.SwitchCurrentActionMap("Flight");
			GameManager.SwitchToFlightMode();
		}
	}

	public void Accelerate(CallbackContext value)
	{
		inputAccelerate = (value.started || value.performed);
	}

	public void Reverse(CallbackContext value)
	{
		inputReverse = (value.started || value.performed);
	}

	public void Rotate(CallbackContext value)
	{
		if (value.performed)
		{
			Vector2 axisValue = value.ReadValue<Vector2>();
			inputDirection = axisValue;
		}

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
		float damage = 10 * (1 - Mathf.Sin(angle));

		/*IDamageable damageable = collision.collider.GetComponentInParent<IDamageable>(); //dealing damage to other hit
		if (damageable != null)
		{
			damageable.DamageShipComponent(damage);
		}*/
		Debug.Log(damage);
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

