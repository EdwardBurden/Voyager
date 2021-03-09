using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using static UnityEngine.InputSystem.InputAction;

public class BuildModeInput : MonoBehaviour
{
	public BuildMode buildMode;
	public InputSystemUIInputModule inputSystem;
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

	public void PlaceComponent(CallbackContext value)
	{
		if (value.started && !inputSystem.IsPointerOverGameObject(0))
		{
			buildMode.PlaceComponent();
		}
	}

	public void MoveUpLevel(CallbackContext value)
	{
		if (value.started)
		{
			buildMode.MoveUp();
		}
	}

	public void MoveDownLevel(CallbackContext value)
	{
		if (value.started)
		{
			buildMode.MoveDown();
		}
	}
}
