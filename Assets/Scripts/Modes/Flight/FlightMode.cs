using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightMode : BaseMode, IMode
{
	public string modeMap;
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }
	public FlightModeUI flightUI => modeUI.GetComponent<FlightModeUI>();

	public FlightModeInput flightInput => modeInput.GetComponent<FlightModeInput>();

	public FlightCamera flightCamera => modeCamera.GetComponent<FlightCamera>();

	private void Awake()
	{
		flightUI.Init(this);
		flightInput.Init(this);
		flightCamera.Init(this);
	}

	public void BeginMode()
	{
		if (GameManager.instance.playerInput.currentActionMap.name != modeMap)
		{
			GameManager.instance.playerInput.SwitchCurrentActionMap(modeMap);
		}
		modeUI.SetActive(true);
		modeCamera.transform.GetChild(0).gameObject.SetActive(true);
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.SetComponentsToFlight();
		}
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.transform.GetChild(0).gameObject.SetActive(false);
		if (Selection.isShipSelected)
		{
			RestShip();
		}
	}

	internal void IncreaseShipSpeed()
	{
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.IncreaseSpeed();
		}
	}

	internal void TurnShipLeft()
	{
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.Rotate(-15);
		}
	}

	internal void TurnShipRight()
	{
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.Rotate(15);
		}
	}

	internal void DecreaseShipSpeed()
	{
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.DecreaseSpeed();
		}
	}

	internal void RestShip()
	{
		if (Selection.isShipSelected)
		{
			Selection.instance.selectedShip.Rest();
		}
	}



	internal void UseLaser() //temp
	{
		LaserSC laserSC = Selection.instance.selectedShip.GetComponentInChildren<LaserSC>();
		if (!laserSC.active && laserSC.CanActiveWeapon())
		{
			Selection.instance.selectedShip.GetComponentInChildren<LaserSC>().ActiveWeapon();
		}
	}

	internal void SwitchToBuild()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

}
