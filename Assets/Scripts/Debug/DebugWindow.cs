using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
	public static DebugWindow instance;

	public string saveFile = "default";
	public string saveLocation = "Saves";
	public ShipControlComponent control;

	private void Awake()
	{
		instance = this;
	}

	public void ConstructShip()
	{
		control.ConstructShip();
	}
	public void Load()
	{
		//get class form json 
		ShipExportInfo shipExportInfo = new ShipExportInfo();//get class form json 
		control = ShipExporter.ConstructFromFile(shipExportInfo);

	}

	public void Save()
	{
		ShipExportInfo shipExportInfo = ShipExporter.ExportToFile(control);
		//save file to default location
	}

}
