using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ShipCharacterController : MonoBehaviour
{
	[SerializeField]
	private PlayerInput shipInput;

	public void Move(CallbackContext value)
	{


	}

	public void SwitchToBuild(CallbackContext value)
	{
		shipInput.SwitchCurrentActionMap("Build");
		//Gamemaneger switch
	}

	public void SwitchToFlight(CallbackContext value)
	{
		shipInput.SwitchCurrentActionMap("Flight");
		//Gamemaneger switch
	}

	public void Attack(CallbackContext value)
	{


	}


	private void OnCollisionEnter(Collision collision)
	{
		foreach (GameObject contact in collision.contacts.Select(x => x.thisCollider.gameObject).Distinct())
		{
			IDamageable damageable = contact.GetComponentInParent<IDamageable>();
			if (damageable != null)
			{
				damageable.DamageShipComponent(50);
			}
		}

	}
}
