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

	public void LoadShipInBuildMode()
	{
		Selection.instance.selectedShip = ShipExporter.LoadShipInBuildMode(tempPrefab, tempSpawnPoint);
	}

	public void LoadShipInBuildMode(Vector3 position, Quaternion rotation)
	{
		Selection.instance.selectedShip = ShipExporter.LoadShipInBuildMode(tempPrefab, position ,rotation);
	}

	public void LoadShipInFlightMode(Vector3 position , Quaternion rotation)
	{
		Selection.instance.selectedShip = ShipExporter.LoadShipInFlightMode(tempPrefab, position, rotation);
	}

	public void LoadShipInFlightMode()
	{
		Selection.instance.selectedShip = ShipExporter.LoadShipInFlightMode(tempPrefab, tempSpawnPoint);
	}

}
