using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSC : ShipComponent, IPowerSupplied
{
	private int powerTotalProduced;
	private int powerProduced => 10;//GetPowerEffect().powerSupplied;

	private void Awake()
	{
		powerTotalProduced = powerProduced;
	}

	public bool CanPowerComponent(int powerRequired)
	{
		return powerTotalProduced - powerRequired >= 0;
	}

	public void PowerComponent(int powerRequired)
	{
		powerTotalProduced -= powerRequired;
	}
}
