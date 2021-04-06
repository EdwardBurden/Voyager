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
		CheckPowerSuppliers();
		CheckRequirementsWithEffects();
		CheckRequirementsWithoutEffects();
	}

	private void CheckPowerSuppliers()
	{
		List<ShipComponent> powerSuppliers = characterController.connectedComponents.Where(x => x.GetPowerEffect() != null && x.GetDefinitionRequirements() != null).ToList();
		foreach (ShipComponent shipComponent in powerSuppliers)
		{
			bool isFulfilled = shipComponent.GetDefinitionRequirements().All(requirement => requirement.IsRequirementFulfilled(this.gameObject, shipComponent));
			shipComponent.status = isFulfilled;
		}
	}

	public void CheckRequirementsWithEffects()
	{
		List<ShipComponent> noEffects = characterController.connectedComponents.Where(x => x.GetDefinitionEffects() == null && x.GetDefinitionRequirements() != null).ToList();
		foreach (ShipComponent shipComponent in noEffects)
		{
			bool isFulfilled = shipComponent.GetDefinitionRequirements().All(requirement => requirement.IsRequirementFulfilled(this.gameObject, shipComponent));
			shipComponent.status = isFulfilled;
		}

	}
	public void CheckRequirementsWithoutEffects()
	{
		List<ShipComponent> noEffects = characterController.connectedComponents.Where(x => x.GetDefinitionEffects() == null && x.GetDefinitionRequirements() != null).ToList();
		foreach (ShipComponent shipComponent in noEffects)
		{
			bool isFulfilled = shipComponent.GetDefinitionRequirements().All(requirement => requirement.IsRequirementFulfilled(this.gameObject, shipComponent));
			shipComponent.status = isFulfilled;
		}
	}
}
