using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour, IMode
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
	}

	public void EndMode()
	{
		//throw new System.NotImplementedException();
	}
}
