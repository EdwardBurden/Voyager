using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PowerRequirementDefinition : RequirementDefinition
{
	[SerializeField]
	public int powerRequired;

	public override bool IsRequirementFulfilled(GameObject ship, ShipComponent thisComponent)
	{
		//does powercontroller have power froma  supplier to this component
		//if poweravialble is >= powerRequired
		//assign this componet to be using that amount
		return true;
	}


}
