using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
	public static DebugWindow instance;

	public ShipControlComponent control;

	private void Awake()
	{
		instance = this;
	}

	public void ConstructShip()
	{
		control.ReConstructShip();

	}
}
