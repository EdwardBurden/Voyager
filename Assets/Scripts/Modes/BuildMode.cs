using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour, IMode
{
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }

	public void BeginMode()
	{
		//show ui

		//throw new System.NotImplementedException();
	}

	public void EndMode()
	{
		//throw new System.NotImplementedException();
	}

	private void Update()
	{
		if (!_active)
		{
			return;
		}
	}

	private void DetectMove() //might need another singleton input manager for these
	{

	}

	private void DetectClick()
	{
		//left click to select and place 
		//right click to center camera look 
		//WASD/controller left-stick to rotate arround centred block
	}
}
