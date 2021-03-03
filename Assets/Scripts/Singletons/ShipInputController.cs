using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using static UnityEngine.InputSystem.InputAction;

public class ShipInputController : SingletonMonoBehaviour<ShipInputController>
{
	BaseMode currentMode;

	public ShipCharacterController selectedShip; // add way to switch when selecting ships //diffenet input classes both active under this gameobject in fuuture
	public ShipComponent selectedBuildComponent; //maybe have different input controller for build mode

	/*CLEAN*/
	public InputSystemUIInputModule inputSystemUI;
	public event Action ShipSelected;
	PlayerInput PlayerInput => GetComponent<PlayerInput>();
	public bool isShipSelected => selectedShip != null;

	//Internals
	internal void TESTSELECTION()
	{
		ShipSelected?.Invoke();
	}



	//Inputs





}
