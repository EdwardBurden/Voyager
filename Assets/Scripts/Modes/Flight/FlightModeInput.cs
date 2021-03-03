using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FlightModeInput : MonoBehaviour
{
	public FlightMode flightMode;

	public void Init(FlightMode mode)
	{
		flightMode = mode;
	}

	//Inputs
	public void SwitchToBuild(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.SwitchToBuild();
		}
	}

	public void SpeedUp(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.IncreaseShipSpeed();
		}
	}

	public void SlowDown(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.DecreaseShipSpeed();
		}
	}

	public void TurnLeft(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.TurnShipLeft();
		}
	}

	public void TurnRight(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.TurnShipRight();
		}
	}

	public void Laser(CallbackContext value)
	{
		if (value.started)
		{
			flightMode.UseLaser();
		}
	}
}
