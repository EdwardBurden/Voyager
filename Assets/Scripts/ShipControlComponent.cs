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

	public void ReConstructShip()
	{
		shipConstructor.ContrustShip();

	}

	public void Addcomponent(ShipComponent shipComponent)
	{
		shipConstructor.AddComponent(shipComponent);
	}

	public void RemoveComponent(ShipComponent shipComponent)
	{
		shipConstructor.RemoveComponent(shipComponent);
	}

}
