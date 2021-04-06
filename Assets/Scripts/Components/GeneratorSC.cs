using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSC : ShipComponent, IPowerSupplied
{
	private int powerTotalProduced;
	private PowerEffectDefinition powerEffect;


	public override void Init(ShipComponentDefinition shipComponentDefinition, int variant)
	{
		base.Init(shipComponentDefinition, variant);
		powerEffect = GetPowerEffect();
		powerTotalProduced = powerEffect.powerSupplied;
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
