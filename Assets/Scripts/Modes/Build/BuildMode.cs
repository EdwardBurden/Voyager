using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuildMode : BaseMode, IMode
{
	public ShipCharacterController tempPrefab;
	public Transform tempSpawnPoint;

	private GameObject previewObject;

	private Vector2 placePosition;

	public string modeMap;
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }

	public BuildModeInput buildInput => modeInput.GetComponent<BuildModeInput>();
	public BuildModeUI buildUI => modeUI.GetComponent<BuildModeUI>();

	private void Awake()
	{
		buildInput.Init(this);
		buildUI.Init(this);
	}
	public void BeginMode()
	{
		if (GameManager.instance.playerInput.currentActionMap.name != modeMap)
		{
			GameManager.instance.playerInput.SwitchCurrentActionMap(modeMap);
		}
		modeUI.SetActive(true);
		modeCamera.gameObject.SetActive(true);

		FocusOnShip();
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.gameObject.SetActive(false);
		ShipInputController.instance.selectedBuildComponent = null;
	}

	internal void ResetShip()
	{
		throw new NotImplementedException();
	}

	internal void LoadShip()
	{
		//will load agina //need load and replace too
		if (Selection.isShipSelected)
		{
			//replace
			Destroy(Selection.selectedShip.gameObject);
		}

		Selection.selectedShip = ShipExporter.LoadShip(tempPrefab, tempSpawnPoint);
		FocusOnShip();
	}

	internal void SaveShip()
	{
		throw new NotImplementedException();
	}

	internal void SwitchToFlight()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

	private void FocusOnShip()
	{
		if (Selection.isShipSelected)
		{
			modeCamera.LookAt = Selection.selectedShip.transform;
			modeCamera.Follow = Selection.selectedShip.transform;
			Selection.selectedShip.SetComponentsToBuild();
		}

	}
}
