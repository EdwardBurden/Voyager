using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugWindow : SingletonMonoBehaviour<DebugWindow>
{
	public string saveFile = "default";
	public string saveLocation = "Saves";
	public ShipCharacterController  shipCharacter;
	public ShipInputController shipinput;

	public Transform spawnPoint;

	public ShipCharacterController prefabController;

	public void ConstructShip()
	{
		shipCharacter.ConstructShip();
	}

	public void Exit()
	{
		Application.Quit();
	}
	public void Load() //todo move out to somewhere else
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
		ShipCharacterController ship = Instantiate(prefabController, null);
		ship.Init();
		List<ShipComponent> components = ShipExporter.ConstructFromFile(shipExportInfo, ship.transform);
		ship.ConstructShip(components);
		GameManager.instance.player = ship;
		shipinput.shipController = ship;
	}

	public void Save() //todo move out to somewhere else
	{
		ShipExportInfo shipExportInfo = ShipExporter.ExportToFile(shipCharacter);
		string path = Path.Combine(Application.persistentDataPath, saveLocation);
		string filePath = Path.Combine(path, saveFile);
		Directory.CreateDirectory(path);
		string jsoncontents = JsonUtility.ToJson(shipExportInfo);
		File.WriteAllText(filePath, jsoncontents);
	}

	public void BuildMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

	public void FlightMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

}
