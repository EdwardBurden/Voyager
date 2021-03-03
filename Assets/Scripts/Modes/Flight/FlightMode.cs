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

	private void Awake()
	{
		flightUI.Init(this);
		flightInput.Init(this);
	}

	public void BeginMode()
	{
		if (GameManager.instance.playerInput.currentActionMap.name != modeMap)
		{
			GameManager.instance.playerInput.SwitchCurrentActionMap(modeMap);
		}
		modeUI.SetActive(true);
		modeCamera.gameObject.SetActive(true);
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.SetComponentsToFlight();
		}
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.gameObject.SetActive(false);
		if (Selection.isShipSelected)
		{
			RestShip();
		}
	}

	internal void IncreaseShipSpeed()
	{
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.IncreaseSpeed();
		}
	}

	internal void TurnShipLeft()
	{
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.Rotate(-15);
		}
	}

	internal void TurnShipRight()
	{
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.Rotate(15);
		}
	}

	internal void DecreaseShipSpeed()
	{
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.DecreaseSpeed();
		}
	}

	internal void RestShip()
	{
		if (Selection.isShipSelected)
		{
			Selection.selectedShip.Rest();
		}
	}

	internal void UseLaser() //temp
	{
		LaserSC laserSC = Selection.selectedShip.GetComponentInChildren<LaserSC>();
		if (!laserSC.active && laserSC.CanActiveWeapon())
		{
			Selection.selectedShip.GetComponentInChildren<LaserSC>().ActiveWeapon();

		}
	}

	internal void SwitchToBuild()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}


}
