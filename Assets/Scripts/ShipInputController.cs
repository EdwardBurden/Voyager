using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using static UnityEngine.InputSystem.InputAction;

public class ShipInputController : SingletonMonoBehaviour<ShipInputController>
{
	public InputSystemUIInputModule inputSystemUI;
	PlayerInput PlayerInput => GetComponent<PlayerInput>();

	public ShipCharacterController shipController; // add way to switch when selecting ships




	public void SwitchToBuild(CallbackContext value)
	{
		if (value.started)
		{
			ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
		}
	}

	public void SwitchToFlight(CallbackContext value)
	{
		if (value.started)
		{
			ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
		}
	}

	public void IncreaseShipSpeed()
	{
		shipController.IncreaseSpeed();
	}

	internal void RotateLeft()
	{
		shipController.Rotate(-15);
	}

	internal void RotateRight()
	{
		shipController.Rotate(15);
	}

	public void DecreaseShipSpeed() 
	{
		shipController.DecreaseSpeed();
	}

	public void RestShip()
	{
		shipController.Rest();
	}

	public void SpeedUp(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}
		if (value.started)
		{
			IncreaseShipSpeed();
		}
	}

	public void SlowDown(CallbackContext value)
	{
		if (shipController == null)
		{
			return;
		}
		if (value.started)
		{
			DecreaseShipSpeed();
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
