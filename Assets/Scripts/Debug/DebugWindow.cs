using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
	public static DebugWindow instance;

	public string saveFile = "default";
	public string saveLocation = "Saves";
	public ControlSC control;

	public Transform spawnPoint;

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
		string path = Path.Combine(Application.persistentDataPath, saveLocation);
		string filePath = Path.Combine(path, saveFile);
		if (!Directory.Exists(path))
		{
			throw new System.Exception("Path Does not exist");
		}

		if (!File.Exists(filePath))
		{
			throw new System.Exception("File Does not exist");
		}
		string jsoncontents = File.ReadAllText(filePath);
		ShipExportInfo shipExportInfo = JsonUtility.FromJson<ShipExportInfo>(jsoncontents);
		control = ShipExporter.ConstructFromFile(shipExportInfo , spawnPoint);
	}

	public void Save()
	{
		ShipExportInfo shipExportInfo = ShipExporter.ExportToFile(control);
		string path = Path.Combine(Application.persistentDataPath, saveLocation);
		string filePath = Path.Combine(path, saveFile);
		Directory.CreateDirectory(path);
		string jsoncontents = JsonUtility.ToJson(shipExportInfo);
		File.WriteAllText(filePath, jsoncontents);
	}

}
