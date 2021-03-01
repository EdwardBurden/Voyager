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
	public ShipCharacterController selectedShip; // add way to switch when selecting ships //diffenet input classes both active under this gameobject in fuuture
	public ShipComponent selectedBuildComponent; //maybe have different input controller for build mode

	/*CLEAN*/
	public InputSystemUIInputModule inputSystemUI;
	public event Action ShipSelected;
	PlayerInput PlayerInput => GetComponent<PlayerInput>();
	public bool isShipSelected => selectedShip != null;

	//Internals
	internal void TESTSELECTION()
	{
		ShipSelected?.Invoke();
	}

	internal void IncreaseShipSpeed()
	{
		if (isShipSelected)
		{
			selectedShip.IncreaseSpeed();
		}
	}

	internal void TurnShipLeft()
	{
		if (isShipSelected)
		{
			selectedShip.Rotate(-15);
		}
	}

	internal void TurnShipRight()
	{
		if (isShipSelected)
		{
			selectedShip.Rotate(15);
		}
	}

	internal void DecreaseShipSpeed()
	{
		if (isShipSelected)
		{
			selectedShip.DecreaseSpeed();
		}
	}

	internal void RestShip()
	{
		if (isShipSelected)
		{
			selectedShip.Rest();
		}
	}

	//Inputs
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

	public void TurnLeft(CallbackContext value)
	{
		if (isShipSelected)
		{
			if (value.started)
			{
				TurnShipLeft();
			}
		}
	}
	public void TurnRight(CallbackContext value)
	{
		if (isShipSelected)
		{
			if (value.started)
			{
				TurnShipRight();
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
