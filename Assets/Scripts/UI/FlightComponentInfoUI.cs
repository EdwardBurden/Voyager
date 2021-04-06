using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightComponentInfoUI : MonoBehaviour
{
	public GameObject requirementPrefab;

	public Text ComponentName;
	public Transform requirements;
	public Transform effects;

	internal void Init(ShipComponent shipComponent)
	{
		ComponentName.text = shipComponent.GetDisplayName();
		foreach (var item in shipComponent.GetDefinitionRequirements())
		{
			GameObject gameObject = Instantiate(requirementPrefab, requirements);
			gameObject.GetComponent<Text>().text = item.GetDisplayText();
		}
	}
}
