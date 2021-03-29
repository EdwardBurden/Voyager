using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class RequirementDefinition
{
	[SerializeField]
	public string name;
	public abstract bool IsRequirementFulfilled(GameObject ship, ShipComponent thisComponent);

}
