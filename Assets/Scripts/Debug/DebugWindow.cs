﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugWindow : SingletonMonoBehaviour<DebugWindow>
{
	FlightMode flight;//debug only
	public string saveFile = "default";
	public string saveLocation = "Saves";

	public Transform spawnPoint;

	public ShipCharacterController prefabController;
	/*
	public void ConstructShip()
	{
		flight.ConstructShip();
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
		ShipCharacterController shipCharacter = Instantiate(prefabController, spawnPoint.transform.position, spawnPoint.transform.rotation, null);
		shipCharacter.Init();
		List<ShipComponent> components = ShipExporter.ConstructFromFile(shipExportInfo, shipCharacter.transform);
		shipCharacter.ConstructShip(components);
		ModeSwitcher.instance.SetSelected(shipCharacter.gameObject);
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
	*/
	public void BuildMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

	public void FlightMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

}
