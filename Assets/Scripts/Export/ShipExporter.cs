using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShipExporter
{
	private static string PATH = "Prefabs";
	internal static List<ShipComponent> ConstructFromFile(ShipExportInfo shipExportInfo, Transform shipExportTransform)
	{
		List<ShipComponent> components = new List<ShipComponent>();
		foreach (ComponentExportInfo info in shipExportInfo.components)
		{
			Type type = ComponentMapping.GetTypeFromInt(info.componentId);
			string filepath = PATH;
			if (!string.IsNullOrWhiteSpace(info.folder))
			{
				filepath += ("/" + info.folder);
			}
			filepath += "/" + type.Name;
			if (info.versionId > 0)
			{
				filepath += (" " + info.versionId);
			}

			ShipComponent loadedComponent = Resources.Load<ShipComponent>(filepath) as ShipComponent;

			ShipComponent shipComponent = GameObject.Instantiate(loadedComponent, info.position + shipExportTransform.position, Quaternion.Euler(info.eulerAngles + shipExportTransform.eulerAngles), shipExportTransform);
			components.Add(shipComponent);
		}
		return components;
	}

	internal static ShipExportInfo ExportToFile(ShipCharacterController shipCharacter)
	{
		ShipExportInfo shipExport = new ShipExportInfo();
		foreach (ShipComponent shipComponent in shipCharacter.GetAllComponents())
		{
			ComponentExportInfo componentExport = new ComponentExportInfo(
		new Vector3(Mathf.RoundToInt(shipComponent.transform.localPosition.x), Mathf.RoundToInt(shipComponent.transform.localPosition.y), Mathf.RoundToInt(shipComponent.transform.localPosition.z)),
				shipComponent.transform.localEulerAngles,
				ComponentMapping.GetIntFromType(shipComponent.GetType()),
				shipComponent.visualId,
				shipComponent.folderRoot);
			shipExport.components.Add(componentExport);
		}
		return shipExport;
	}
}
