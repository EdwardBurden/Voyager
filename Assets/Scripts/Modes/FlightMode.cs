using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightMode : MonoBehaviour, IMode
{
	private bool _active;
	public bool isActive { get => _active; set => _active = value; }
	public void BeginMode()
	{

		//throw new System.NotImplementedException();
	}

	public void EndMode()
	{
		//throw new System.NotImplementedException();
	}
}
