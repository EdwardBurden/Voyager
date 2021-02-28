using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightMode : BaseMode, IMode
{
	public string modeMap;
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }
	public void BeginMode()
	{

		if (GameManager.instance.playerInput.currentActionMap.name != modeMap)
		{
			GameManager.instance.playerInput.SwitchCurrentActionMap(modeMap);
		}
		modeUI.SetActive(true);
		modeCamera.gameObject.SetActive(true);
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.gameObject.SetActive(false);
	}
}
