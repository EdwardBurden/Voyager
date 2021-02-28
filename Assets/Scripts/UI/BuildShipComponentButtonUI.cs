using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildShipComponentButtonUI : MonoBehaviour
{
	[HideInInspector]
	public ShipComponent shipComponent;

	public Button button;
	public event Action onClick;

	public void Init(UnityAction<ShipComponent> action , ShipComponent shipComponent)
	{
		button.onClick.AddListener(()=> action.Invoke(shipComponent));
		GetComponentInChildren<Text>().text = shipComponent.name;
	}


}
