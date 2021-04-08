using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildMode : BaseMode, IMode
{
	public GameObject objectPrefab;
	public GameObject floorPrefab;

	private ShipComponentDefinition buildDefinition;
	private int buildvariant;

	private GameObject previewObject;
	private GameObject previewFloor;
	private Vector3 placePosition;
	private Quaternion placeRotation;

	public LayerMask buildFloorLayer;

	private int level;

	public string modeMap;
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }

	public BuildModeInput buildInput => modeInput.GetComponent<BuildModeInput>();
	public BuildModeUI buildUI => modeUI.GetComponent<BuildModeUI>();

	public BuildCamera buildCamera => modeCamera.GetComponent<BuildCamera>();

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
			buildCamera.FocusOnShip(Selection.instance.selectedShip.transform.position);
		}
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.transform.GetChild(0).gameObject.SetActive(false);
		Destroy(previewObject);
		Destroy(previewFloor);
		if (Selection.isShipSelected)
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
		bool hasHit = GetPlacementPosition();

		if (previewFloor == null)
		{
			previewFloor = Instantiate(floorPrefab);
		}
		else
		{
			previewFloor.gameObject.transform.position = buildCamera.transform.position;
		}

		if (previewObject == null)
		{
			previewObject = Instantiate(objectPrefab, Selection.instance.selectedShip.transform);
		}
		else
		{
			previewObject.SetActive(hasHit);
			previewObject.transform.localPosition = placePosition;
			previewObject.transform.rotation = placeRotation;
		}
	}

	private bool GetPlacementPosition()
	{
		ShipCharacterController ship = Selection.instance.selectedShip;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		bool hasHit = Physics.Raycast(ray, out hit, 1000, buildFloorLayer);
		if (hasHit)
		{

			Vector3 localHit = ship.transform.InverseTransformPoint(hit.point);
			Vector3 poition = new Vector3(Mathf.Round(localHit.x), level - 1, Mathf.Round(localHit.z));
			placePosition = poition + hit.normal;
			placeRotation = Selection.instance.selectedShip.transform.rotation;
		}

		return hasHit;
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
		buildCamera.UpdateElevation(level);


	}

	internal void MoveDown()
	{
		level--;
		ShowActiveShipLevel();
		buildCamera.UpdateElevation(level);
	}

	internal void ResetShip()
	{
		if (Selection.isShipSelected)
		{
			Vector3 pos = Selection.instance.selectedShip.transform.position;
			Quaternion rot = Selection.instance.selectedShip.transform.rotation;
			Destroy(Selection.instance.selectedShip.gameObject);
			GameManager.instance.LoadShipInBuildMode(pos, rot);
		}
	}

	internal void SwitchSelection(ShipComponentDefinition componentDefinition, int buildvariant)
	{
		buildDefinition = componentDefinition;
		this.buildvariant = buildvariant;
	}

	internal void PlaceComponent()
	{
		if (Selection.isShipSelected && buildDefinition != null)
		{
			if (!Utils.IsComponentAtPosition(placePosition, Selection.instance.selectedShip.connectedComponents))
			{
				ShipComponent shipComponent = GameObject.Instantiate(buildDefinition.prefabVariants[buildvariant], Selection.instance.selectedShip.transform);
				shipComponent.transform.localPosition = placePosition;
				shipComponent.transform.rotation = placeRotation;
				shipComponent.Init(buildDefinition, buildvariant);
				ShipConstructor.AddComponent(shipComponent, Selection.instance.selectedShip);
				GameEventsManager.instance.ComponentAdded(Selection.instance.selectedShip, shipComponent);
			}
		}
	}

	internal void RemoveComponent()
	{
		if (Selection.isShipSelected)
		{
			if (Utils.IsComponentAtPosition(placePosition, Selection.instance.selectedShip.connectedComponents))
			{
				ShipComponent shipComponent = ShipConstructor.GetComponentAtPosition(placePosition, Selection.instance.selectedShip);
				ShipConstructor.DestroyComponent(shipComponent, Selection.instance.selectedShip);
				GameEventsManager.instance.ComponentRemoved(Selection.instance.selectedShip, shipComponent);
			}
		}
	}

	internal void LoadShip()
	{
		if (Selection.isShipSelected)
		{
			ShipConstructor.SetComponentsToFlight(Selection.instance.selectedShip);
		}
		GameManager.instance.LoadShipInBuildMode();
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
