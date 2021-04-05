using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FlightComponentListUI : MonoBehaviour
{
	public Button buttonPrefab;
	private ShipCharacterController shipCharacterController;

	public void Init(ShipCharacterController shipCharacterController)
	{
	}

	public void Refresh()
	{
		foreach (Transform item in transform)
		{
			Destroy(item.gameObject);
		}

		foreach (var item in Selection.instance.selectedShip.connectedComponents.Where(x => x.GetDefinitionRequirements() != null && x.GetDefinitionRequirements().Count > 0))
		{
			Button button = Instantiate(buttonPrefab, this.transform);
			button.GetComponentInChildren<Text>().text = item.GetDisplayName() + item.status.ToString();
		}

	}

}
