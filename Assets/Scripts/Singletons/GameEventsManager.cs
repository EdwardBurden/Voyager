using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventsManager : SingletonMonoBehaviour<GameEventsManager>
{
	public Text eventText;

	public event Action<ShipCharacterController, ShipComponent> onComponentAdded;
	public void ComponentAdded(ShipCharacterController shipCharacterController , ShipComponent shipComponent)
	{
		onComponentAdded?.Invoke(shipCharacterController, shipComponent);
		eventText.text = "Component Added";
	}

	public event Action<ShipCharacterController, ShipComponent> onComponentRemoved;
	public void ComponentRemoved(ShipCharacterController shipCharacterController, ShipComponent shipComponent)
	{
		onComponentRemoved?.Invoke(shipCharacterController, shipComponent);
		eventText.text = "Component Removed";
	}

	public event Action<ShipCharacterController, ShipComponent> onComponentDestroyed;
	public void ComponentDestroyed(ShipCharacterController shipCharacterController, ShipComponent shipComponent)
	{
		onComponentDestroyed?.Invoke(shipCharacterController, shipComponent);
		eventText.text = "Component Destroyed";
	}




	public event Action<GameObject> onShipLoaded;
	public void ShipLoaded(GameObject gameObject)
	{
		onShipLoaded?.Invoke(gameObject);
		eventText.text = "Ship Loaded";
	}

	public event Action<Type> onModeChanged;
	public void ModeChanged(Type modeType)
	{
		onModeChanged?.Invoke(modeType);
		eventText.text = "Mode Changed";
	}

	public event Action onShipSelected;
	public void ShipSelected()
	{
		onShipSelected?.Invoke();
		eventText.text = "Ship Selected";
	}
}
