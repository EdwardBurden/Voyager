using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipExportInfo
{
	public List<ComponentExportInfo> components;

	public ShipExportInfo()
	{
		this.components = new List<ComponentExportInfo>();
	}
}
