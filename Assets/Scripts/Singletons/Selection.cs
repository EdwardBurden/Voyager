using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : SingletonMonoBehaviour<Selection>
{
	public static ShipCharacterController selectedShip;

	public static bool isShipSelected => selectedShip != null;
}
