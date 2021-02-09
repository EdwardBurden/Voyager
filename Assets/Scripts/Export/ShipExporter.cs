using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShipExporter
{
	private static string PATH = "Prefabs";
	internal static ControlSC ConstructFromFile(ShipExportInfo shipExportInfo, Transform shipExportTransform)
	{
		ControlSC control = null;
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

			ShipComponent shipComponent = GameObject.Instantiate(loadedComponent, info.position + shipExportTransform.position, Quaternion.Euler(info.eulerAngles + shipExportTransform.eulerAngles), null);
			if (shipComponent is ControlSC controlSC)
			{
				control = controlSC;
			}
		}
		return control;
	}

	internal static ShipExportInfo ExportToFile(ControlSC control)
	{
		ShipExportInfo shipExport = new ShipExportInfo();
		foreach (ShipComponent shipComponent in control.GetAllComponents())
		{
			ComponentExportInfo componentExport = new ComponentExportInfo(
				shipComponent.transform.localPosition,
				shipComponent.transform.localEulerAngles,
				ComponentMapping.GetIntFromType(shipComponent.GetType()),
				shipComponent.visualId,
				shipComponent.folderRoot);
			shipExport.components.Add(componentExport);
		}
		return shipExport;
	}
}
