using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public ShipCharacterController player;
	public ShipInputController playerInputController;

	public PlayerInput playerInput => playerInputController.GetComponent<PlayerInput>();

	private void Start()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

}
