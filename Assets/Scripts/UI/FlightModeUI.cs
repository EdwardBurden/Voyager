using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightModeUI : MonoBehaviour
{
	FlightMode flightMode;

	public FlightComponentListUI flightComponentListUI;

	public Button increaseSpeedButton;
	public Button decreaseSpeedButton;
	public Button restSpeedButton;
	public Button leftButton;
	public Button rightButton;

	private void Awake()
	{
		increaseSpeedButton.onClick.AddListener(InreaseSpeed);
		decreaseSpeedButton.onClick.AddListener(DecreaseSpeed);
		restSpeedButton.onClick.AddListener(RestSpeed);
		leftButton.onClick.AddListener(Turnleft);
		rightButton.onClick.AddListener(TurnRight);
	}

	public void Init(FlightMode mode)
	{
		flightMode = mode;
		flightComponentListUI.Init();
	}

	public void InreaseSpeed()
	{
		flightMode.IncreaseShipSpeed(); //could change to call player directly
	}

	public void DecreaseSpeed()
	{
		flightMode.DecreaseShipSpeed();
	}

	public void RestSpeed()
	{
		flightMode.RestShip();
	}

	public void TurnRight()
	{
		flightMode.TurnShipRight();
	}

	public void Turnleft()
	{
		flightMode.TurnShipLeft();
	}

	public void SwitchToBuild()
	{
		flightMode.SwitchToBuild();
	}

	internal void Refresh(ShipCharacterController selectedShip)
	{
		flightComponentListUI.Refresh(selectedShip);
	}
}
