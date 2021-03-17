using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public PlayerInput playerInput;

	public ShipCharacterController tempPrefab;
	public Transform tempSpawnPoint;

	private void Start()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

	public void Exit()
	{
		Application.Quit(0);
	}

	public void LoadShip()
	{
		Selection.instance.selectedShip = ShipExporter.LoadShip(tempPrefab, tempSpawnPoint);
	}

	public void LoadShip(Vector3 position , Quaternion rotation)
	{
		Selection.instance.selectedShip = ShipExporter.LoadShip(tempPrefab, position, rotation);
	}

}
