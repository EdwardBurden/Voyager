using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class RequirementDefinition
{
	public abstract bool IsRequirementFulfilled(GameObject ship, ShipComponent thisComponent);

	public abstract bool GetIcon();

	public abstract string GetDisplayText();
}
