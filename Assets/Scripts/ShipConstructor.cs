using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConstructor
{
	private int radius = 2;

	public GameObject shipParent;
	public ShipControlComponent shipControlComponent;
	public List<ShipComponent> connectedComponents;

	public ShipConstructor(ShipControlComponent shipControl)
	{
		shipControlComponent = shipControl;
		//ContrustShip();
	}

	public void ContrustShip()
	{
		shipParent = CreateShipParent();
		connectedComponents = FindShipComponents(shipControlComponent.transform.position);
		foreach (ShipComponent ship in connectedComponents)
		{
			AttachComponentToParent(ship);
		}

		SetupControl();
	}

	private void AttachComponentToParent(ShipComponent shipComponent)
	{
		shipComponent.shipControl = shipControlComponent;
		shipComponent.transform.parent = shipParent.transform;
		Rigidbody rigidbody = shipComponent.GetComponent<Rigidbody>();
		if (rigidbody)
		{
			GameObject.Destroy(rigidbody);
		}
	}

	private GameObject CreateShipParent()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Test";
		gameObject.AddComponent<Rigidbody>();
		return gameObject;
	}

	private void SetupControl()
	{
		shipControlComponent.transform.parent = shipParent.transform;
		Rigidbody controlRigidbody = shipControlComponent.GetComponent<Rigidbody>();
		if (controlRigidbody)
		{
			GameObject.Destroy(controlRigidbody);
		}
	}


	private List<ShipComponent> FindShipComponents(Vector3 position, List<ShipComponent> foundComponents = null)
	{
		if (foundComponents == null)
		{
			foundComponents = new List<ShipComponent>();
		}
		Collider[] foundColliders = Physics.OverlapSphere(position, radius, shipControlComponent.componentLayer);
		foreach (Collider collider in foundColliders)
		{
			ShipComponent shipComponent = collider.gameObject.GetComponent<ShipComponent>();
			if (shipComponent != null && !foundComponents.Contains(shipComponent) && shipComponent != shipControlComponent)
			{
				foundComponents.Add(shipComponent);
				FindShipComponents(shipComponent.transform.position, foundComponents);

			}
		}
		return foundComponents;
	}

	public void AddComponent(ShipComponent shipComponent)
	{
		connectedComponents.Add(shipComponent);
		AttachComponentToParent(shipComponent);
	}

	internal void RemoveComponent(ShipComponent shipComponent)
	{
		connectedComponents.Remove(shipComponent);
		shipComponent.gameObject.AddComponent<Rigidbody>();
		shipComponent.transform.parent = null;
	}
}
