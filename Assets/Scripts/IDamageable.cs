using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	void DamageShipComponent(float dmg);

	void DestroyComponent();

	void UpdateDamageState();

}
