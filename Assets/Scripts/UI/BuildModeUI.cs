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
	public GameObject selectionSectionPrefab;

	public Button upLevelButton;
	public Button downLevelButton;

	public Button exportButton;
	public Button importButton;
	public Button resetButton;

	public Transform componentTransform;

	public void Awake()
	{
		List<ShipComponentDefinition> definitions = Resources.LoadAll(ShipExporter.PATH).Cast<ShipComponentDefinition>().ToList();
		foreach (ShipComponentDefinition def in definitions)
		{
			GameObject gameObject = Instantiate(selectionSectionPrefab, componentTransform);
			for (int i = 0; i < def.prefabVariants.Length; i++)
			{
				BuildShipComponentButtonUI buttonUI = Instantiate(selectionPrefab, gameObject.transform);
				buttonUI.Init(SelectComponent, def,i );
			}
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

	public void SelectComponent(ShipComponentDefinition componentDefinition , int variant)
	{
		buildMode.SwitchSelection(componentDefinition , variant);
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
