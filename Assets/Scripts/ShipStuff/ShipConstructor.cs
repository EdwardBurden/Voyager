using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipConstructor
{
	private int radius = 2;

	public ShipCharacterController controller;
	public ControlSC control => connectedComponents.FirstOrDefault(x => x is ControlSC) as ControlSC;
	public List<ShipComponent> connectedComponents;


	public ShipConstructor(ShipCharacterController characterController)
	{
		controller = characterController;

	}
	public void ContrustShip(List<ShipComponent> shipComponents)
	{
		if (connectedComponents != null)
		{
			connectedComponents.RemoveAll(x => x == null);
		}
		connectedComponents = shipComponents;
		FindControl(connectedComponents);
		foreach (ShipComponent ship in connectedComponents)
		{
			AttachComponentToParent(ship);
		}
	}

	public void ContrustShip()
	{
		if (connectedComponents != null)
		{
			connectedComponents.RemoveAll(x => x == null);
		}
		connectedComponents = FindShipComponents(control.transform.position, connectedComponents);
		FindControl(connectedComponents);
		foreach (ShipComponent ship in connectedComponents)
		{
			AttachComponentToParent(ship);
		}
		
	}

	internal void UpdateLayers(int layer)
	{
		foreach (ShipComponent component in connectedComponents)
		{
			SetLayerRecursively(component.gameObject , layer);
		}
	}

	private void AttachComponentToParent(ShipComponent shipComponent)
	{
		shipComponent.characterController = controller;
		shipComponent.transform.parent = controller.transform;
		SetLayerRecursively(shipComponent.gameObject, controller.defaultlayer);
	}

	public static void SetLayerRecursively(GameObject obj, int layer) //to do move to helper
	{
		obj.layer = layer;

		foreach (Transform child in obj.transform)
		{
			SetLayerRecursively(child.gameObject, layer);
		}
	}

	private List<ShipComponent> FindShipComponents(Vector3 position, List<ShipComponent> foundComponents = null)
	{
		if (foundComponents == null)
		{
			foundComponents = new List<ShipComponent>();
		}
		Collider[] foundColliders = Physics.OverlapSphere(position, radius, controller.constructionLayer);
		foreach (Collider collider in foundColliders)
		{
			ShipComponent shipComponent = collider.gameObject.GetComponentInParent<ShipComponent>();
			if (shipComponent != null && !foundComponents.Contains(shipComponent) && shipComponent.characterController == null && !(shipComponent is ControlSC))
			{
				foundComponents.Add(shipComponent);
				FindShipComponents(shipComponent.transform.position, foundComponents);
			}
		}
		return foundComponents;
	}

	private ControlSC FindControl(List<ShipComponent> shipComponents)
	{
		return shipComponents.Find(x => x is ControlSC) as ControlSC;
	}

	public void AddComponent(ShipComponent shipComponent)
	{
		connectedComponents.Add(shipComponent);
		AttachComponentToParent(shipComponent);
	}

	internal void RemoveComponent(ShipComponent shipComponent)
	{
		connectedComponents.Remove(shipComponent);
		if (shipComponent.gameObject.GetComponent<Rigidbody>() == null)
		{
			shipComponent.gameObject.AddComponent<Rigidbody>();
		}
		shipComponent.transform.parent = null;
		shipComponent.shipRigidbody.isKinematic = false;
		shipComponent.shipCollider.enabled = true;
		shipComponent.ChangeLayerAfterWait();
		SetLayerRecursively(shipComponent.gameObject, controller.destructionLayer);
	}
}
