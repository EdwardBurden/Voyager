using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public GameObject shipCharctercontrollerPrefab;

	private void Awake()
	{
		//ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

	internal static void SwitchToFlightMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(FlightMode));
	}

	internal static void SwitchToBuildMode()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}
}
