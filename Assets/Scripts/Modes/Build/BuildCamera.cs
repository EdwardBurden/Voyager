using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.InputSystem.InputAction;

public class BuildCamera : MonoBehaviour
{
	public CinemachineVirtualCamera camera;
	private BuildMode buildMode;

	public Transform childTransform;

	private Vector3 moveDirectionInput;
	private float zoomInput;

	private float speed;
	private float rotationAmount = 1; //todo make publicv
	private float movementTime = 5;

	private bool rotating;
	private Vector2 startRotationPosition;
	private Quaternion startverticalRotation;
	private Quaternion startHorizontalRotation;

	[HideInInspector]
	public Vector3 newPosition;
	[HideInInspector]
	public Quaternion horizontalRotation;
	[HideInInspector]
	public Quaternion vertivalRotation;
	[HideInInspector]
	public Vector3 newChildPosition;

	public void Init(BuildMode mode)
	{
		buildMode = mode;
		newPosition = transform.position;
		horizontalRotation = transform.rotation;
		newChildPosition = camera.transform.localPosition;
		vertivalRotation = childTransform.localRotation;
	}

	private void Update()
	{
		camera.LookAt = this.transform;


		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);


		newChildPosition += camera.transform.forward * zoomInput * speed;
		camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, newChildPosition, Time.deltaTime * movementTime);



		if (rotating)
		{
			Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
			Vector2 differnec = startRotationPosition - pos;

			horizontalRotation = Quaternion.Euler(startHorizontalRotation.eulerAngles + (Vector3.up * -differnec.x * 360));
			vertivalRotation = Quaternion.Euler(startverticalRotation.eulerAngles + (Vector3.right * differnec.y * 180));
		}
		transform.rotation = Quaternion.Lerp(transform.rotation, horizontalRotation, Time.deltaTime * movementTime);
		childTransform.localRotation = Quaternion.Lerp(childTransform.localRotation, vertivalRotation, Time.deltaTime * movementTime);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
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

		vector += transform.forward * moveDirectionInput.y;
		vector += transform.right * moveDirectionInput.x;
		vector.Normalize();
		Vector3 poition = new Vector3(Mathf.Round(vector.x), 0, Mathf.Round(vector.z));

		newPosition += poition;
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

	public void Rotate(CallbackContext value)
	{
		if (value.started)
		{
			Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
			startRotationPosition = pos;
			startverticalRotation = childTransform.localRotation;
			startHorizontalRotation = transform.rotation;
			Debug.Log(pos);
			rotating = true;
		}

		if (value.canceled)
		{

			Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
			Debug.Log(pos);
			rotating = false;
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

