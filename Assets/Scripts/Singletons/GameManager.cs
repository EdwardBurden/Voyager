using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public PlayerInput playerInput;

	private void Start()
	{
		ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

}
