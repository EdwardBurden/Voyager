using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipPowerController : MonoBehaviour
{
	private ShipCharacterController characterController;
	private ComponentPathfinding componentPathfinding;

	private List<ShipComponent> powerUsers => characterController.connectedComponents.Where(x => x is IPowerRequired).ToList();

	private List<ShipComponent> powerSuppliers => characterController.connectedComponents.Where(x => x is IPowerSupplied).ToList();

	private List<ShipComponent> powerConduits => characterController.connectedComponents.Where(x => x is IPowerConduit).ToList();

	private void Awake()
	{
		characterController = GetComponent<ShipCharacterController>();
		componentPathfinding = new ComponentPathfinding();
	}

	private void OnDrawGizmos()
	{
	
		foreach (var item in powerUsers)
		{	List<ComponentPathNode> path = componentPathfinding.FindPath(powerConduits, item, powerSuppliers[0]);
			Color color = new Color(1, Convert.ToInt32(path!= null), 1);
			Gizmos.color = color;
			Gizmos.DrawCube(item.transform.position, Vector3.one);
		}
	}

	//use ipowerrequired to find powerrequired
	//use ipowersupplier to find powersuppliers
	//is a component powered? , can irequired find is upply and does it have enough left after every other irequired takes its amount
	//total power generated
	//have enough power?

}
