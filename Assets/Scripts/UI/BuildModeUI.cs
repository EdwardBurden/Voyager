using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildModeUI : MonoBehaviour
{
	BuildMode buildMode;
	public BuildShipComponentButtonUI selectionPrefab;

	public Button upLevelButton;
	public Button downLevelButton;

	public Button exportButton;
	public Button importButton;
	public Button resetButton;

	public Transform componentTransform;

	public void Awake()
	{
		List<GameObject> components = Resources.LoadAll(ShipExporter.PATH).Cast<GameObject>().ToList();
		foreach (GameObject gameobject in components)
		{
			BuildShipComponentButtonUI buttonUI = Instantiate(selectionPrefab, componentTransform);
			buttonUI.Init(SelectComponent, gameobject.GetComponent<ShipComponent>());
		}
		exportButton.onClick.AddListener(Save);
		importButton.onClick.AddListener(Load);
		resetButton.onClick.AddListener(ResetBuild);

		upLevelButton.onClick.AddListener(UpLevel);
		downLevelButton.onClick.AddListener(DownLevel);
	}

	public void Init(BuildMode mode)
	{
		buildMode = mode;
	}
	public void Save()
	{
		buildMode.SaveShip();
	}

	public void Load()
	{
		buildMode.LoadShip();
	}

	public void ResetBuild()
	{
		buildMode.ResetShip();
	}

	public void SelectComponent(ShipComponent shipComponent)
	{
		buildMode.SwitchSelection(shipComponent);
	}

	public void UpLevel()
	{
		buildMode.MoveUp();
	}

	public void DownLevel()
	{
		buildMode.MoveDown();
	}

}
