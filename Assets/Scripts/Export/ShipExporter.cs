using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExporter : MonoBehaviour
{
	internal static ShipControlComponent ConstructFromFile(ShipExportInfo shipExportInfo)
	{
		throw new NotImplementedException();
	}

	internal static ShipExportInfo ExportToFile(ShipControlComponent control)
	{
		ShipExportInfo shipExport = new ShipExportInfo();
		foreach (ShipComponent shipComponent in control.GetAllComponents())
		{
			ComponentExportInfo componentExport = new ComponentExportInfo(shipComponent.transform.localPosition, shipComponent.transform.localEulerAngles, ComponentMapping.GetIntFromType(shipComponent.GetType()));
			shipExport.components.Add(componentExport);
		}
		return shipExport;
	}
}
