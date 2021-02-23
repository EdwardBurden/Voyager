using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightMode : MonoBehaviour, IMode
{
	public string modeMap;
	private bool _active;
	public GameObject flightUI;
	public bool isActive { get => _active; set => _active = value; }
	public void BeginMode()
	{

		if (GameManager.instance.playerInput.currentActionMap.name != modeMap)
		{
			GameManager.instance.playerInput.SwitchCurrentActionMap(modeMap);
		}
		flightUI.gameObject.SetActive(true);
	}

	public void EndMode()
	{
		flightUI.gameObject.SetActive(false);
	}
}
