using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FlightModeInput : MonoBehaviour
{
	public FlightMode flightMode;
	private bool ZoomInHeld = false;
	private bool ZoomOutHeld = false;

	public void Init(FlightMode mode)
	{
		flightMode = mode;
	}

	//Inputs
	private void Update()
	{
		if (ZoomInHeld)
		{
			flightMode.CameraZoomIn();
		}
		if (ZoomOutHeld)
		{
			flightMode.CameraZoomout();
		}
	}


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

	public void CameraZoomIn(CallbackContext value)
	{
		if (value.started)
		{
			ZoomInHeld = true;
			return;
		}
		if (ZoomInHeld == true && value.canceled)
		{
			ZoomInHeld = false;
		}
	}

	public void CameraZoomOut(CallbackContext value)
	{
		if (value.started)
		{
			ZoomOutHeld = true;
			return;
		}
		if (ZoomOutHeld == true && value.canceled)
		{
			ZoomOutHeld = false;
		}
	}

	public void CameraZoomAxis(CallbackContext value)
	{
		if (value.performed)
		{
			float amount = value.ReadValue<float>();
			flightMode.CameraZoom(amount);
		}
	}

	public void CameraMove()
	{


	}

}
