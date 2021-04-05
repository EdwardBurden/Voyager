using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RequirementController : MonoBehaviour
{
	private ShipCharacterController characterController;
	private void Awake()
	{
		characterController = GetComponent<ShipCharacterController>();
	}

	public void CheckRequirements()
	{
		foreach (ShipComponent item in characterController.connectedComponents.Where(x => x.GetDefinitionRequirements() != null && x.GetDefinitionRequirements().Count > 0))
		{
			bool isFulfilled = item.GetDefinitionRequirements().All(requirement => requirement.IsRequirementFulfilled(this.gameObject, item));
			item.status = isFulfilled;
		}
	}


}
