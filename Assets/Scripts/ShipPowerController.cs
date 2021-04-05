using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipPowerController : MonoBehaviour
{
	private ShipCharacterController characterController;
	private ComponentPathfinding componentPathfinding;

	private IEnumerable<ShipComponent> powerUsers => characterController.connectedComponents.Where(x => x.GetPowerRequirement() != null);

	private List<ShipComponent> powerSuppliers => characterController.connectedComponents.Where(x => x is IPowerSupplied).ToList(); //to do change to effects list getter

	private List<ShipComponent> powerConduits => characterController.connectedComponents.Where(x => x is IPowerConduit).ToList();

	private void Awake()
	{
		characterController = GetComponent<ShipCharacterController>();
		componentPathfinding = new ComponentPathfinding();
	}

	public bool CheckShipComponentPower(ShipComponent shipComponent, PowerRequirementDefinition powerRequirement)
	{
		foreach (var item in powerSuppliers)
		{
			List<ComponentPathNode> path = componentPathfinding.FindPath(powerConduits, shipComponent, item);
			if (path != null && path.Last().component == item)
			{
				IPowerSupplied powerSupplied = item.GetComponent<IPowerSupplied>();
				if (powerSupplied.CanPowerComponent(powerRequirement.powerRequired))
				{
					powerSupplied.PowerComponent(powerRequirement.powerRequired);
					return true;
				}
			}
		}
		return false;

	}

	//Get Event When changing modes
	//Get Event When component added
	//Get Event When component removed/destroyed

	private void OnDrawGizmos()
	{

		/*foreach (var item in powerUsers)
		{
			List<ComponentPathNode> path = componentPathfinding.FindPath(powerConduits, item, powerSuppliers[0]);
			Color color = new Color(1, Convert.ToInt32(path != null), 1);
			Gizmos.color = color;
			Gizmos.DrawCube(item.transform.position, Vector3.one);
		}
	*/
	}

}
