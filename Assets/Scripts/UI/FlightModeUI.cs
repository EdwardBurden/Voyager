using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightModeUI : MonoBehaviour
{
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

	public void InreaseSpeed()
	{
		ShipInputController.instance.IncreaseShipSpeed(); //could change to call player directly
	}

	public void DecreaseSpeed()
	{
		ShipInputController.instance.DecreaseShipSpeed();
	}

	public void RestSpeed()
	{
		ShipInputController.instance.RestShip();
	}

	public void TurnRight()
	{
		ShipInputController.instance.TurnShipRight();
	}

	public void Turnleft()
	{
		ShipInputController.instance.TurnShipLeft();
	}


}
