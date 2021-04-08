using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RequirementController : SingletonMonoBehaviour<RequirementController>
{
	private void Awake()
	{
		GameEventsManager.instance.onShipLoaded += CheckRequirements;
		GameEventsManager.instance.onComponentAdded += (x, y) => CheckRequirements(x.gameObject);
		GameEventsManager.instance.onComponentRemoved += (x, y) => CheckRequirements(x.gameObject);
		GameEventsManager.instance.onComponentDestroyed += (x, y) => CheckRequirements(x.gameObject);

	}


	public void CheckRequirements(GameObject gameObject)
	{
		if (ModeSwitcher.instance.activeMode.GetType() != typeof(FlightMode))
		{
			return;
		}

		ShipCharacterController characterController = gameObject.GetComponent<ShipCharacterController>();
		List<ShipComponent> components = characterController.connectedComponents;
		List<ShipComponent> powerSuppliers = components.Where(x => x.GetPowerEffect() != null && x.GetDefinitionRequirements() != null).ToList();
		List<ShipComponent> effects = components.Where(x => x.GetDefinitionEffects() != null && x.GetDefinitionRequirements() != null).ToList();
		List<ShipComponent> noEffects = components.Where(x => x.GetDefinitionEffects() == null && x.GetDefinitionRequirements() != null).ToList();
		CheckRequirements(powerSuppliers, gameObject);
		CheckRequirements(effects, gameObject);
		CheckRequirements(noEffects, gameObject);
	}

	private void CheckRequirements(List<ShipComponent> components, GameObject gameObject)
	{
		foreach (ShipComponent shipComponent in components)
		{
			bool isFulfilled = shipComponent.GetDefinitionRequirements().All(requirement => requirement.IsRequirementFulfilled(gameObject, shipComponent));
			shipComponent.status = isFulfilled;
		}
	}
}
