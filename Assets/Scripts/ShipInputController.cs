using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ShipInputController : MonoBehaviour
{
	PlayerInput PlayerInput => GetComponent<PlayerInput>();

	public ShipCharacterController shipController;

	public void SwitchToBuild(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}
		if (value.started)
		{
			ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
		}
	}

	public void SwitchToFlight(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}
		if (value.started)
		{
			ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
		}
	}

	public void Accelerate(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}

		shipController.inputAccelerate = (value.started || value.performed);
	}

	public void Reverse(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}

		shipController.inputReverse = (value.started || value.performed);
	}

	public void Rotate(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}

		if (value.performed)
		{
			Vector2 axisValue = value.ReadValue<Vector2>();
			shipController.inputDirection = axisValue;
		}

	}

	public void Laser(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}

		if (value.started)
		{
			LaserSC laserSC = shipController.GetComponentInChildren<LaserSC>();
			if (!laserSC.active && laserSC.CanActiveWeapon())
			{
				shipController.GetComponentInChildren<LaserSC>().ActiveWeapon();

			}
		}
	}
}
