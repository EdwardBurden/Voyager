using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewRequirementDefinition : RequirementDefinition
{
	public int CrewRequired;

	public override bool GetDisplayText()
	{
		throw new System.NotImplementedException();
	}

	public override bool GetIcon()
	{
		throw new System.NotImplementedException();
	}

	public override bool IsRequirementFulfilled(GameObject ship, ShipComponent thisComponent)
	{
		return true;
	}
}
