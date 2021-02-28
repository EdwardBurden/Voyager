using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BuildModeUI : MonoBehaviour
{
	public BuildShipComponentButtonUI selectionPrefab;

	public void Awake()
	{
		List<GameObject> components = Resources.LoadAll(ShipExporter.PATH).Cast<GameObject>().ToList();
		foreach (GameObject gameobject in components)
		{
			BuildShipComponentButtonUI buttonUI = Instantiate(selectionPrefab, this.transform);
			buttonUI.Init(SelectComponent, gameobject.GetComponent<ShipComponent>());
		}
	}

	public void SelectComponent(ShipComponent shipComponent)
	{
		ShipInputController.instance.selectedBuildComponent = shipComponent;

	}

}
