using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitcher : SingletonMonoBehaviour<ModeSwitcher>
{
	[SerializeField]
	private FlightMode flightMode;
	[SerializeField]
	private BuildMode buildMode;

	private Dictionary<Type, IMode> modes;

	IMode activeMode;

	public void Awake()
	{
		modes = new Dictionary<Type, IMode>()
		{
			{ typeof(FlightMode) , flightMode },
			{ typeof(BuildMode) , buildMode }
		};
	}

	public void ChangeMode(Type type)
	{
		if (activeMode != null)
		{
			activeMode.EndMode();
			activeMode.isActive = false;
		}
		activeMode = modes[type];
		activeMode.BeginMode();
		activeMode.isActive = true;
	}
}
