using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPathNode
{
	public ShipComponent component;
	public Vector3 localPosition => component.transform.localPosition;

	public int x => Mathf.RoundToInt(localPosition.x);
	public int y => Mathf.RoundToInt(localPosition.y);
	public int z => Mathf.RoundToInt(localPosition.z);


	public int gCost;
	public int hCost;
	public int fCost;

	public ComponentPathNode lastNode;

	public ComponentPathNode(ShipComponent shipComponent)
	{
		component = shipComponent;
	}

	public void CalculateFCost()
	{
		fCost = gCost + hCost;
	}
}
