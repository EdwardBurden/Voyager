using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PowerRequirementDefinition : RequirementDefinition
{
	[SerializeField]
	public int powerRequired;

	public override string GetDisplayText()
	{
		return "Power needed";
	}

	public override bool GetIcon()
	{
		throw new NotImplementedException();
	}

	public override bool IsRequirementFulfilled(GameObject ship, ShipComponent thisComponent)
	{
		return ship.GetComponent<ShipPowerController>().CheckShipComponentPower(thisComponent ,this);
	}


}
