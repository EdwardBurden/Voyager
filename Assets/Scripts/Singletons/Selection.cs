using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class Selection : SingletonMonoBehaviour<Selection>
{
	public InputSystemUIInputModule inputSystemUIInput;
	public static ShipCharacterController selectedShip;

	public static bool isPointerOverSelectable => instance.GetSelectable() != null;

	public static bool isShipSelected => selectedShip != null;

	public GameObject GetSelectable()
	{
		if (!inputSystemUIInput.IsPointerOverGameObject(Mouse.current.deviceId))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
			bool hasHit = Physics.Raycast(ray, out hit, 1000);
			if (hasHit)
			{
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
