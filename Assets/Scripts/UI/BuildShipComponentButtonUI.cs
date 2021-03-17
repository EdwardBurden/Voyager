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

	public void Init(UnityAction<ShipComponentDefinition,int> action , ShipComponentDefinition definition , int variant)
	{
		button.onClick.AddListener(()=> action.Invoke(definition,variant));
		GetComponentInChildren<Text>().text = definition.displayName;
	}


}
