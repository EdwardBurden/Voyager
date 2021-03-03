using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BuildModeInput : MonoBehaviour
{
	public BuildMode buildMode;

	public void Init(BuildMode mode)
	{
		buildMode = mode;
	}

	//Inputs
	public void SwitchToFlight(CallbackContext value)
	{
		if (value.started)
		{
			buildMode.SwitchToFlight();
		}
	}
}
