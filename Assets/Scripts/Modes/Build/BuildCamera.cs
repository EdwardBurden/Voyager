using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class BuildCamera : MonoBehaviour
{
	public CinemachineVirtualCamera camera;
	private BuildMode buildMode;


	private Vector2 moveDirectionInput;
	private float zoomInput;
	private float rotateInput;

	private float speed;
	private float rotationAmount = 1; //todo make publicv
	private float movementTime = 5;

	[HideInInspector]
	public Vector3 newPosition;
	[HideInInspector]
	public Quaternion newRotation;
	[HideInInspector]
	public Vector3 newChildPosition;

	public void Init(BuildMode mode)
	{
		buildMode = mode;
		newPosition = transform.position;
		newRotation = transform.rotation;
		newChildPosition = camera.transform.localPosition;
	}

	private void Update()
	{
		camera.LookAt = this.transform;

		//newPosition += transform.forward * moveDirectionInput.y * speed;
		//newPosition += transform.right * moveDirectionInput.x * speed;
		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);

		newChildPosition += camera.transform.forward * zoomInput * speed;
		//newRotation *= Quaternion.Euler(Vector3.up * rotateInput * rotationAmount);

		camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, newChildPosition, Time.deltaTime * movementTime);


		//	transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
	}

	public void FocusOnShip(Vector3 shipPosition)
	{
		newPosition = shipPosition;
		newPosition += transform.right * moveDirectionInput.x * speed;
		UpdateElevation(0);
	}

	public void Move(CallbackContext value)
	{
		moveDirectionInput = value.ReadValue<Vector2>();
		Vector3 vector = Vector3.zero;
		vector += transform.forward * Mathf.RoundToInt(moveDirectionInput.y);
		vector += transform.right * Mathf.RoundToInt(moveDirectionInput.x);
		newPosition += vector;
	}

	public void ZoomIn(CallbackContext value)
	{
		zoomInput = HandleInput(value, zoomInput, -1);
	}

	public void ZoomOut(CallbackContext value)
	{
		zoomInput = HandleInput(value, zoomInput, 1);
	}

	public void ZoomAxis(CallbackContext value)
	{
		if (value.performed)
		{
			zoomInput = value.ReadValue<float>() / 120.0f; ;
		}
	}



	internal void UpdateElevation(int level)
	{
		newPosition[1] = level;
		//Transform lookAt = new Transform(Selection.instance.selectedShip.transform);
		//lookAt.position = new Vector3(lookAt.position.x, level, lookAt.position.z);
		camera.LookAt = this.transform;
		//camera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(0, level, 0);
		//transform.position = new Vector3(Selection.instance.selectedShip.transform.position.x, level, Selection.instance.selectedShip.transform.position.z);
		//transform.rotation = Selection.instance.selectedShip.transform.rotation;
	}


	//can rotate around 
	private float HandleInput(CallbackContext context, float value, float targetValue, float defaultValue = 0)
	{
		if (context.started)
		{
			return targetValue;
		}
		if (context.canceled)
		{
			return defaultValue;
		}
		return value;
	}
}

