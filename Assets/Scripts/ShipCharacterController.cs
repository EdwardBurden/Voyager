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

	private float maxvelocity;
	private float accelerationPerUpdate = 1f;


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

	private void FixedUpdate()
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

	private void Fixed_Accelerate()
	{
		rigidbody.velocity += transform.forward * accelerationPerUpdate;
	}

	private void Fixed_Rest()
	{
		rigidbody.velocity += (Vector3.zero - (rigidbody.velocity * accelerationPerUpdate));
	}

	private void Fixed_Reverse()
	{
		rigidbody.velocity += -transform.forward * accelerationPerUpdate;
	}


	private void OnCollisionEnter(Collision collision)
	{
		foreach (GameObject contact in collision.contacts.Select(x => x.thisCollider.gameObject).Distinct())
		{
			IDamageable damageable = contact.GetComponentInParent<IDamageable>();
			if (damageable != null)
			{
				damageable.DamageShipComponent(50);
			}
		}

	}
}
