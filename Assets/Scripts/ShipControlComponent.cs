using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlComponent : ShipComponent
{
	public LayerMask componentLayer;
	ShipConstructor shipConstructor;
	private void Awake()
	{
		shipConstructor = new ShipConstructor(this);
	}

	public void ConstructShip()
	{
		shipConstructor.ContrustShip();

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
