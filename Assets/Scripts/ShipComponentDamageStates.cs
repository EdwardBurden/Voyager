using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShipComponentDamageStates
{
	public Material material;
	[Range(0, 1)]
	public float healthThreshold;
}
