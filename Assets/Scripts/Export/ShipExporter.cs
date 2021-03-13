using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShipExporter
{
	public static string PATH = "Prefabs/ShipComponents";
	public static string saveFile = "default";
	public static string saveLocation = "Saves";

	internal static ShipCharacterController LoadShip(ShipCharacterController prefabController, Transform spawnPoint)
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
		ShipCharacterController shipCharacter = GameObject.Instantiate(prefabController, spawnPoint.transform.position, spawnPoint.transform.rotation, null);
		shipCharacter.Init();
		List<ShipComponent> components = ShipExporter.ConstructFromFile(shipExportInfo, shipCharacter.transform);
		ShipConstructor.ContrustShip(components, shipCharacter);
		return shipCharacter;
	}

	internal static void SaveShip(ShipCharacterController shipCharacter)
	{
		ShipExportInfo shipExportInfo = ShipExporter.ExportToFile(shipCharacter);
		string path = Path.Combine(Application.persistentDataPath, saveLocation);
		string filePath = Path.Combine(path, saveFile);
		Directory.CreateDirectory(path);
		string jsoncontents = JsonUtility.ToJson(shipExportInfo);
		File.WriteAllText(filePath, jsoncontents);
	}

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
		foreach (ShipComponent shipComponent in shipCharacter.connectedComponents)
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
