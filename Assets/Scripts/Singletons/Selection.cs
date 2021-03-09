using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class Selection : SingletonMonoBehaviour<Selection>
{
	public InputSystemUIInputModule inputSystemUIInput;
	public ShipCharacterController selectedShip;

	public static bool isPointerOverSelectable => instance.GetSelectable() != null;

	public static bool isShipSelected => instance.selectedShip != null;


	public void SetSelection()
	{
		GameObject gameObject = GetSelectable();
		if (gameObject == null)
		{
			return;
		}
		ShipCharacterController shipCharacterController = gameObject.GetComponent<ShipCharacterController>();
		if (shipCharacterController == null)
		{
			return;
		}
		selectedShip = shipCharacterController;
	}



	public GameObject GetSelectable()
	{
		if (!inputSystemUIInput.IsPointerOverGameObject(Mouse.current.deviceId))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
			bool hasHit = Physics.Raycast(ray, out hit, 1000);
			if (hasHit)
			{
				if (hit.rigidbody == null)
				{
					return null;
				}
				ISelectable selectable = hit.rigidbody.gameObject.GetComponent<ISelectable>();
				if (selectable != null)
				{
					return hit.rigidbody.gameObject;
				}
			}
		}
		return null;
	}

}
