using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSC : ShipComponent, IPowerSupplied
{
	public int GetPowerRadius()
	{
		return 5; //in future get the power info from list of requirements
	}

	public int GetPowerSupply()
	{
		return 5;
	}
}
