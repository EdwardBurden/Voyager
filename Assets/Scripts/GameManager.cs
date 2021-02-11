using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public GameObject shipCharctercontrollerPrefab;

	private void Awake()
	{
		//ModeSwitcher.instance.ChangeMode(typeof(BuildMode));
	}

}
