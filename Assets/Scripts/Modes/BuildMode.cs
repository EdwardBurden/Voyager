using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : BaseMode, IMode
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
		modeCamera.LookAt = GameManager.instance.player.transform;
		modeCamera.Follow = GameManager.instance.player.transform;
		modeUI.SetActive(true);
		modeCamera.gameObject.SetActive(true);
		ShipInputController.instance.RestShip();
	}

	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.gameObject.SetActive(false);
	}
}
