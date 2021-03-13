using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BuildCamera : MonoBehaviour
{
	public CinemachineVirtualCamera camera;
	private BuildMode buildMode;

	public void Init(BuildMode mode)
	{
		buildMode = mode;
	}

	internal void FocusOnShip(int level)
	{
		//Transform lookAt = new Transform(Selection.instance.selectedShip.transform);
		//lookAt.position = new Vector3(lookAt.position.x, level, lookAt.position.z);
		camera.LookAt = Selection.instance.selectedShip.transform;
		//camera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(0, level, 0);
		//transform.position = new Vector3(Selection.instance.selectedShip.transform.position.x, level, Selection.instance.selectedShip.transform.position.z);
		//transform.rotation = Selection.instance.selectedShip.transform.rotation;
	}
}

