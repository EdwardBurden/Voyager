using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : BaseMode, IMode
{
	public GameObject previewObject;

	private Vector2 placePosition;

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
		ShipInputController.instance.RestShip();
		if (GameManager.instance.player)
		{
			modeCamera.LookAt = GameManager.instance.player.transform;
			modeCamera.Follow = GameManager.instance.player.transform;
			GameManager.instance.player.SetComponentsToBuild();
		}
	}

	private void Update()
	{

		//using raycast get poition on ship,
		//fomrat position into int position 
		//if position hasnt chnaged, spawn a fake object

		if (ShipInputController.instance.selectedBuildComponent != null)
		{

		}
	}


	public void EndMode()
	{
		modeUI.SetActive(false);
		modeCamera.gameObject.SetActive(false);
		ShipInputController.instance.selectedBuildComponent = null;
	}
}
