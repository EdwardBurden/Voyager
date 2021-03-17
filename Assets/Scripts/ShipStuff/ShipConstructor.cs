using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ShipConstructor
{
	private static int lazyConstructionLayermask = 8;
	public static int destructionLayer = 9;
	private static int defaultlayer = 0;
	private static int radius = 50;

	public static List<ShipComponent> ContrustShip(List<ShipComponent> connectedComponents, ShipCharacterController characterController)
	{
		if (connectedComponents != null)
		{
			connectedComponents.RemoveAll(x => x == null);
		}

		foreach (ShipComponent component in connectedComponents)
		{
			AttachComponentToParent(component, characterController);
		}
		return connectedComponents;
	}

	public static List<ShipComponent> ContrustShip(ControlSC control, ShipCharacterController characterController, LayerMask layerMask)
	{
		List<ShipComponent> connectedComponents = new List<ShipComponent>();
		if (connectedComponents != null)
		{
			connectedComponents.RemoveAll(x => x == null);
		}
		connectedComponents = FindShipComponents(control.transform.position, characterController.transform, layerMask, connectedComponents);
		foreach (ShipComponent component in connectedComponents)
		{
			AttachComponentToParent(component, characterController);
		}
		return connectedComponents;
	}

	public static void UpdateLayers(int layer, List<ShipComponent> connectedComponents)
	{
		foreach (ShipComponent component in connectedComponents)
		{
			SetLayerRecursively(component.gameObject, layer);
		}
	}

	private static void AttachComponentToParent(ShipComponent shipComponent, ShipCharacterController shipCharacter)
	{
		shipComponent.characterController = shipCharacter;
		shipComponent.transform.parent = shipCharacter.transform;
	}

	public static void SetLayerRecursively(GameObject obj, int layer) //to do move to helper
	{
		obj.layer = layer;

		foreach (Transform child in obj.transform)
		{
			SetLayerRecursively(child.gameObject, layer);
		}
	}

	private static List<ShipComponent> FindShipComponents(Vector3 position, Transform parentTransform, int layer, List<ShipComponent> foundComponents = null)
	{
		if (foundComponents == null)
		{
			foundComponents = new List<ShipComponent>();
		}
		Vector3[] surrounding = GetSurroundingComponents(position, parentTransform);
		Collider[] foundColliders = surrounding.SelectMany(x => Physics.OverlapSphere(x, 1, layer)).ToArray(); //could be more effiecint
		foreach (Collider collider in foundColliders)
		{
			Debug.Log("F");
			ShipComponent shipComponent = collider.gameObject.GetComponentInParent<ShipComponent>();
			if (shipComponent != null && !foundComponents.Contains(shipComponent) && shipComponent.characterController == null && !(shipComponent is ControlSC))
			{
				Debug.Log("A");
				foundComponents.Add(shipComponent);
				FindShipComponents(shipComponent.transform.position, parentTransform, layer, foundComponents);
			}
		}
		return foundComponents;
	}


	public static Vector3[] GetSurroundingComponents(Vector3 shipComponent, Transform transform)
	{
		Vector3[] positions = new Vector3[]
		{
			shipComponent + transform.forward,
			shipComponent - transform.forward,
			shipComponent + transform.right,
			shipComponent - transform.right,
			shipComponent + transform.up,
			shipComponent - transform.up
		};
		return positions;
	}

	public static void AddComponent(ShipComponent shipComponent, ShipCharacterController shipCharacter)
	{
		shipCharacter.connectedComponents.Add(shipComponent);
		AttachComponentToParent(shipComponent, shipCharacter);
	}

	public static void RemoveComponent(ShipComponent shipComponent, ShipCharacterController shipCharacter)
	{
		shipCharacter.connectedComponents.Remove(shipComponent);
		if (shipComponent.gameObject.GetComponent<Rigidbody>() == null)
		{
			shipComponent.gameObject.AddComponent<Rigidbody>();
		}
		shipComponent.transform.parent = null;
		shipComponent.shipRigidbody.isKinematic = false;
		shipComponent.shipCollider.enabled = true;
		shipComponent.ChangeLayerAfterWait(defaultlayer);
		SetLayerRecursively(shipComponent.gameObject, destructionLayer);
	}

	public static void DestroyComponent(ShipComponent shipComponent, ShipCharacterController shipCharacter)
	{
		shipCharacter.connectedComponents.Remove(shipComponent);
		GameObject.Destroy(shipComponent.gameObject);
	}

	public static bool IsComponentAtPosition(Vector3 localPosition, ShipCharacterController shipCharacterController)
	{
		return shipCharacterController.connectedComponents.Any(x => Vector3.Distance(localPosition, x.transform.localPosition) < 0.001f);
	}

	public static ShipComponent GetComponentAtPosition(Vector3 localPosition, ShipCharacterController shipCharacterController)
	{
		return shipCharacterController.connectedComponents.FirstOrDefault(x => Vector3.Distance(localPosition, x.transform.localPosition) < 0.001f);
	}

	public static void SetComponentsToBuild(ShipCharacterController characterController)
	{
		UpdateLayers(lazyConstructionLayermask, characterController.connectedComponents);
	}
	public static void SetComponentsToFlight(ShipCharacterController characterController)
	{
		UpdateLayers(defaultlayer, characterController.connectedComponents);
	}

}
