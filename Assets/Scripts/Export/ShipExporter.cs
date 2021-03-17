using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ShipExporter
{
	public static string PATH = "Data/";
	public static string saveFile = "default";
	public static string saveLocation = "Saves";

	internal static ShipCharacterController LoadShip(ShipCharacterController prefabController, Transform spawnTransform)
	{
		return LoadShip(prefabController, spawnTransform.position, spawnTransform.rotation);
	}

	internal static ShipCharacterController LoadShip(ShipCharacterController prefabController, Vector3 spawnPosition, Quaternion spawnRotation)
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
		ShipCharacterController shipCharacter = GameObject.Instantiate(prefabController, spawnPosition, spawnRotation, null);
		List<ShipComponent> components = ShipExporter.ConstructFromFile(shipExportInfo, shipCharacter.transform);
		shipCharacter.connectedComponents = ShipConstructor.ContrustShip(components, shipCharacter);
		shipCharacter.Init();
		return shipCharacter;
	}

	//get scriptablobject
	//spawn
	//apply save file info(damage, other stuff)


	internal static void SaveShip(ShipCharacterController shipCharacter)
	{
		ShipExportInfo shipExportInfo = ShipExporter.ExportToFile(shipCharacter);
		string path = Path.Combine(Application.persistentDataPath, saveLocation);
		string filePath = Path.Combine(path, saveFile);
		Directory.CreateDirectory(path);
		string jsoncontents = JsonUtility.ToJson(shipExportInfo);
		File.WriteAllText(filePath, jsoncontents);
	}

	private static List<ShipComponentDefinition> LoadDefinitionFromResources(ShipExportInfo shipExportInfo)
	{
		List<ShipComponentDefinition> loadedDefinitions = new List<ShipComponentDefinition>();
		IEnumerable<string> definitions = shipExportInfo.components.Select(x => x.definitionName).Distinct();
		foreach (string definition in definitions)
		{
			ShipComponentDefinition shipComponentDefinition = Resources.Load<ShipComponentDefinition>(PATH + definition);
			loadedDefinitions.Add(shipComponentDefinition);
		}
		return loadedDefinitions;
	}

	internal static List<ShipComponent> ConstructFromFile(ShipExportInfo shipExportInfo, Transform shipExportTransform)
	{
		List<ShipComponent> components = new List<ShipComponent>();
		List<ShipComponentDefinition> loadedDefinitions = LoadDefinitionFromResources(shipExportInfo);

		foreach (ComponentExportInfo info in shipExportInfo.components)
		{
			ShipComponentDefinition componentDefinition = loadedDefinitions.FirstOrDefault(x => x.name == info.definitionName);
			ShipComponent shipComponent = GameObject.Instantiate(componentDefinition.prefabVariants[info.variant], shipExportTransform);
			shipComponent.transform.localPosition = info.position;
			shipComponent.transform.localEulerAngles = info.eulerAngles;
			shipComponent.Init(componentDefinition , info.variant);
			components.Add(shipComponent);
		}
		return components;
	}

	internal static ShipExportInfo ExportToFile(ShipCharacterController shipCharacter)
	{
		ShipExportInfo shipExport = new ShipExportInfo();
		foreach (ShipComponent shipComponent in shipCharacter.connectedComponents)
		{
			ComponentExportInfo componentExport = new ComponentExportInfo(shipComponent.transform.localPosition, shipComponent.transform.localEulerAngles, shipComponent.GetDefinitionName(), shipComponent.GetDefinitionVariant());

			shipExport.components.Add(componentExport);
		}
		return shipExport;
	}
}
