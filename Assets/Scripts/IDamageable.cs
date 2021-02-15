using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	/*	ShipComponentDamageStates[] damageStates { get; set; }
		int damageStateIndex { get; set; }

		float explosiveForce { get; }
		float explosiveRadius { get; }
		float maxComponentHealth { get; }
		float componentHealth { get; }

		private float healthPercentage => componentHealth / maxComponentHealth;
	*/

	void DamageShipComponent(float dmg);

	void DestroyComponent();

	void UpdateDamageState();

}
