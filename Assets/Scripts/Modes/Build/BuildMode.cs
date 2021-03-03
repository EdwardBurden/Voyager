using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildMode : BaseMode, IMode
{
	public GameObject previewPrefab;
	public ShipCharacterController tempPrefab;
	public Transform tempSpawnPoint;

	private ShipComponent buildComponent;
	private GameObject previewObject;
	private Vector3 placePosition;

	public LayerMask constructionLayer;

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

	private void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		//Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Camera.main.transform.forward* 1000);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		bool hasHit = Physics.Raycast(ray, out hit, 1000, constructionLayer);
		if (hasHit)
		{
			Transform objectHit = hit.collider.transform;
			Vector3 poition = new Vector3(Mathf.Round(objectHit.position.x), Mathf.Round(objectHit.position.y), Mathf.Round(objectHit.position.z));
			Vector3 normal = new Vector3(Mathf.Round(hit.normal.x), Mathf.Round(hit.normal.y), Mathf.Round(hit.normal.z));
			placePosition = poition + normal;
			//get normal of hit , 
			//placePosition = normal + hit positon =
			// Do something with the object that was hit by the raycast.
		}

		if (previewObject == null)
		{
			previewObject = Instantiate(previewPrefab);
		}
		else
		{
			previewObject.SetActive(hasHit);
			previewObject.transform.position = placePosition;
		}
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

	internal void SwitchSelection(ShipComponent shipComponent)
	{
		buildComponent = shipComponent;
	}

	internal void PlaceComponent()
	{
		if (Selection.isShipSelected && buildComponent != null)
		{
			GameObject.Instantiate(buildComponent, placePosition, Quaternion.identity, Selection.selectedShip.transform);
		}
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
