using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
	public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
	{
		float multiplier = 1;
		for (int i = 0; i < decimalPlaces; i++)
		{
			multiplier *= 10f;
		}
		return new Vector3(
			Mathf.Round(vector3.x * multiplier) / multiplier,
			Mathf.Round(vector3.y * multiplier) / multiplier,
			Mathf.Round(vector3.z * multiplier) / multiplier);
	}

	public static List<ShipComponent> GetSurroundingComponents(List<ShipComponent> connectedComponents, ShipComponent shipComponent)
	{
		List<ShipComponent> shipComponents = new List<ShipComponent>();
		Vector3 localposition = shipComponent.transform.localPosition;
		AddSurroundingComponentToList(connectedComponents, shipComponents, localposition + Vector3.forward);
		AddSurroundingComponentToList(connectedComponents, shipComponents, localposition - Vector3.forward);
		AddSurroundingComponentToList(connectedComponents, shipComponents, localposition + Vector3.right);
		AddSurroundingComponentToList(connectedComponents, shipComponents, localposition - Vector3.right);
		return shipComponents;
	}

	private static void AddSurroundingComponentToList(List<ShipComponent> connectedComponents, List<ShipComponent> shipComponents, Vector3 testPosition)
	{
		ShipComponent forward = GetComponentAtPosition(connectedComponents, testPosition);
		if (forward != null)
		{
			shipComponents.Add(forward);
		}
	}

	public static ShipComponent GetComponentAtPosition(List<ShipComponent> connectedComponents, Vector3 localPosition)
	{
		return connectedComponents.FirstOrDefault(x => Vector3.Distance(x.transform.localPosition, localPosition) < 0.01f);
	}

	public static bool IsComponentAtPosition(Vector3 localPosition, List<ShipComponent> connectedComponents)
	{
		return GetComponentAtPosition(connectedComponents, localPosition) != null;
	}
}

