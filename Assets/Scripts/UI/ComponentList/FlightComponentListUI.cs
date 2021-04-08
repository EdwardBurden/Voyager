using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FlightComponentListUI : MonoBehaviour
{
	public GameObject buttonPrefab;
	public GameObject categoryPrefab;
	public GameObject hoverprefab;

	public void Awake()
	{
		GameEventsManager.instance.onShipSelected += Refresh;
	}

	public void Refresh()
	{
		foreach (Transform item in this.transform)
		{
			Destroy(item.gameObject);
		}


		ShipCharacterController shipCharacterController = Selection.instance.selectedShip;
		IEnumerable<IGrouping<ComponentDisplayCategory, ShipComponent>> categorys = shipCharacterController.connectedComponents.GroupBy(x => x.GetDefinition().displayCategory);
		var categoryEnums = Enum.GetValues(typeof(ComponentDisplayCategory));
		foreach (ComponentDisplayCategory categoryEnum in categoryEnums)
		{
			FlightComponentCategoryUI flightComponentCategoryUI = Instantiate(categoryPrefab, this.transform).GetComponent<FlightComponentCategoryUI>();
			flightComponentCategoryUI.categoryName.text = categoryEnum.ToString();
			IEnumerable<ShipComponent> comps = categorys.FirstOrDefault(x => x.Key == categoryEnum);
			if (comps != null)
			{
				foreach (ShipComponent shipComponent in comps)
				{
					FlightComponentUI flightComponentUI = Instantiate(buttonPrefab, flightComponentCategoryUI.listHolder).GetComponent<FlightComponentUI>();
					flightComponentUI.name.text = shipComponent.GetDisplayName();
					flightComponentUI.icon = shipComponent.GetDisplayIcon();
				}
			}
		}
	}

}
