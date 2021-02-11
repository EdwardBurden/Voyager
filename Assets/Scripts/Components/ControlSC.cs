using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSC : ShipComponent
{
	public LayerMask componentLayer;
	[HideInInspector]
	public ShipConstructor shipConstructor;
	[HideInInspector]

	public ShipCharacterController shipController;
	protected void Awake()
	{
		shipConstructor = new ShipConstructor(this);
	}

	public ShipCharacterController ConstructShip()
	{
		shipConstructor.ContrustShip();
		return shipController;

	}

	public void Addcomponent(ShipComponent shipComponent)
	{
		shipConstructor.AddComponent(shipComponent);
	}

	internal IEnumerable<ShipComponent> GetAllComponents()
	{
		return shipConstructor.connectedComponents;
	}

	public void RemoveComponent(ShipComponent shipComponent)
	{
		shipConstructor.RemoveComponent(shipComponent);
	}
}
