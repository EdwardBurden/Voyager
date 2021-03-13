using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildMode : BaseMode, IMode
{
	public GameObject previewPrefab;

	private ShipComponent buildComponent;
	private GameObject previewObject;
	private Vector3 placePosition;
	private Quaternion placeRotation;

	public LayerMask constructionLayer;

	public string modeMap;
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }

	public BuildModeInput buildInput => modeInput.GetComponent<BuildModeInput>();
	public BuildModeUI buildUI => modeUI.GetComponent<BuildModeUI>();

	public BuildCamera buildCamera => modeCamera.GetComponent<BuildCamera>();

	private int level;


	private void Awake()
	{
		buildInput.Init(this);
		buildUI.Init(this);
		buildCamera.Init(this);
	}

	private void Update()
	{
		if (!_active)
		{
			return;
		}
		PreviewPlacement();
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
			ShipConstructor.SetComponentsToBuild(Selection.instance.selectedShip);
			level = 0;
			ShowActiveShipLevel();
			buildCamera.FocusOnShip(level);
		}
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.transform.GetChild(0).gameObject.SetActive(false);
		Destroy(previewObject); if (Selection.isShipSelected)
		{
			ShipCharacterController shipCharacter = Selection.instance.selectedShip;
			shipCharacter.connectedComponents.ForEach(x => x.gameObject.SetActive(true));
		}
	}

	private void PreviewPlacement()
	{
		if (!Selection.isShipSelected)
		{
			return;
		}
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		bool hasHit = Physics.Raycast(ray, out hit, 1000, constructionLayer);
		if (hasHit)
		{
			Transform objectHit = hit.collider.transform;
			Vector3 poition = new Vector3(Mathf.Round(objectHit.position.x), Mathf.Round(objectHit.position.y), Mathf.Round(objectHit.position.z));
			Vector3 normal = new Vector3(Mathf.Round(hit.normal.x), Mathf.Round(hit.normal.y), Mathf.Round(hit.normal.z));
			placePosition = objectHit.position + hit.normal;
			placeRotation = objectHit.rotation;
		}
		if (previewObject == null)
		{
			previewObject = Instantiate(previewPrefab);
		}
		else
		{
			previewObject.SetActive(hasHit);
			previewObject.transform.position = placePosition;
			previewObject.transform.rotation = placeRotation;
		}
	}

	private void ShowActiveShipLevel() //can use fancy shader in future
	{
		ShipCharacterController shipCharacter = Selection.instance.selectedShip;
		List<ShipComponent> comps = shipCharacter.connectedComponents;
		foreach (ShipComponent comp in comps)
		{
			int position = Mathf.RoundToInt(comp.gameObject.transform.position.y);
			comp.gameObject.SetActive(position <= level);
		}

	}


	internal void MoveUp()
	{
		level++;
		ShowActiveShipLevel();
		buildCamera.FocusOnShip(level);


	}
	internal void MoveDown()
	{
		level--;
		ShowActiveShipLevel();
		buildCamera.FocusOnShip(level);
	}



	internal void ResetShip()
	{
		if (Selection.isShipSelected)
		{
			Destroy(Selection.instance.selectedShip.gameObject);
			GameManager.instance.LoadShip();
		}
	}

	internal void SwitchSelection(ShipComponent shipComponent)
	{
		buildComponent = shipComponent;
	}

	internal void PlaceComponent()
	{
		if (Selection.isShipSelected && buildComponent != null)
		{
			ShipComponent shipComponent = GameObject.Instantiate(buildComponent, placePosition, placeRotation, Selection.instance.selectedShip.transform);
			ShipConstructor.AddComponent(shipComponent, Selection.instance.selectedShip);
		}
	}

	internal void LoadShip()
	{
		if (Selection.isShipSelected)
		{
			ShipConstructor.SetComponentsToFlight(Selection.instance.selectedShip);
		}
		GameManager.instance.LoadShip();
	}

	internal void SaveShip()
	{
		if (Selection.isShipSelected)
		{
			//Selection.selectedShip.ConstructShip();
			ShipExporter.SaveShip(Selection.instance.selectedShip);
		}
	}

	internal void SwitchToFlight()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

}
