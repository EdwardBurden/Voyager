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

	public ShipCharacterController selectedShip; // add way to switch when selecting ships

	public bool isShipSelected => selectedShip != null;

	//when ship selected
	public event Action ShipSelected;

	public void TESTSELECTION()
	{
		ShipSelected?.Invoke();
	}

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
		if (isShipSelected)
		{
			selectedShip.IncreaseSpeed();
		}
	}

	internal void RotateLeft()
	{
		if (isShipSelected)
		{
			selectedShip.Rotate(-15);
		}
	}

	internal void RotateRight()
	{
		if (isShipSelected)
		{
			selectedShip.Rotate(15);
		}
	}

	public void DecreaseShipSpeed()
	{
		if (isShipSelected)
		{
			selectedShip.DecreaseSpeed();
		}
	}

	public void RestShip()
	{
		if (isShipSelected)
		{
			selectedShip.Rest();
		}
	}

	public void SpeedUp(CallbackContext value)
	{
		if (isShipSelected)
		{
			if (value.started)
			{
				IncreaseShipSpeed();
			}
		}
	}

	public void SlowDown(CallbackContext value)
	{
		if (isShipSelected)
		{
			if (value.started)
			{
				DecreaseShipSpeed();
			}
		}
	}

	public void Laser(CallbackContext value)
	{
		if (isShipSelected)
		{
			if (value.started)
			{
				LaserSC laserSC = selectedShip.GetComponentInChildren<LaserSC>();
				if (!laserSC.active && laserSC.CanActiveWeapon())
				{
					selectedShip.GetComponentInChildren<LaserSC>().ActiveWeapon();

				}
			}
		}
	}
}
