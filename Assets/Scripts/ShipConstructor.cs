using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConstructor
{
	private int radius = 2;

	public GameObject shipParent;
	public ControlSC control;
	public List<ShipComponent> connectedComponents;

	public ShipConstructor(ControlSC shipControl)
	{
		control = shipControl;
	}

	public void ContrustShip()
	{
		shipParent = CreateShipParent();
		connectedComponents = FindShipComponents(control.transform.position);
		foreach (ShipComponent ship in connectedComponents)
		{
			AttachComponentToParent(ship);
		}

		SetupControl();
	}

	private void AttachComponentToParent(ShipComponent shipComponent)
	{
		shipComponent.shipControl = control;
		shipComponent.transform.parent = shipParent.transform;
		shipComponent.gameObject.layer = 0;
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
		gameObject.AddComponent<ShipParent>();
		return gameObject;
	}

	private void SetupControl()
	{
		control.transform.parent = shipParent.transform;
		Rigidbody controlRigidbody = control.GetComponent<Rigidbody>();
		if (controlRigidbody)
		{
			GameObject.Destroy(controlRigidbody);
		}
		connectedComponents.Add(control);
	}

	public void RemoveDisconnectedComponents()
	{


	}

	private List<ShipComponent> FindShipComponents(Vector3 position, List<ShipComponent> foundComponents = null)
	{
		if (foundComponents == null)
		{
			foundComponents = new List<ShipComponent>();
		}
		Collider[] foundColliders = Physics.OverlapSphere(position, radius, control.componentLayer);
		foreach (Collider collider in foundColliders)
		{
			ShipComponent shipComponent = collider.gameObject.GetComponent<ShipComponent>();
			if (shipComponent != null && !foundComponents.Contains(shipComponent) && shipComponent != control && shipComponent.shipControl == null && !(shipComponent is ControlSC))
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
		shipComponent.shipRigidbody.isKinematic = false;
		shipComponent.shipCollider.enabled = true;
		shipComponent.ChangeLayerAfterWait();
		shipComponent.gameObject.layer = 9;
	}
}
