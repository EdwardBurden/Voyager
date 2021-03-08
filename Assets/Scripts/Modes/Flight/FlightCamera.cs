using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class FlightCamera : MonoBehaviour
{
	private FlightMode flightMode;
	public Transform childTransform;
	private Vector2 moveDirectionInput;
	private float rotateInput;
	private float zoomInput;

	private float rotationAmount = 1;
	public float movementTime = 1;

	public float normalSpeed;
	public float fastSpeed;
	private float speed;

	[HideInInspector]
	public Vector3 newPosition;
	[HideInInspector]
	public Vector3 newChildPosition;
	[HideInInspector]
	public Quaternion newRotation;

	public void Init(FlightMode mode)
	{
		flightMode = mode;
		newPosition = transform.position;
		newRotation = transform.rotation;
		newChildPosition = childTransform.localPosition;
		speed = normalSpeed;
	}

	private void Update()
	{
		newPosition += transform.forward * moveDirectionInput.y * speed;
		newPosition += transform.right * moveDirectionInput.x * speed;
		newChildPosition += new Vector3(0, zoomInput * speed, 0);
		newRotation *= Quaternion.Euler(Vector3.up * rotateInput * rotationAmount);

		childTransform.localPosition = Vector3.Lerp(childTransform.localPosition, newChildPosition, Time.deltaTime * movementTime);

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
	}

	public void CameraZoomIn(CallbackContext value)
	{
		zoomInput = HandleInput(value, zoomInput, -1);
	}

	public void CameraZoomOut(CallbackContext value)
	{
		zoomInput = HandleInput(value, zoomInput, 1);
	}

	public void CameraZoomAxis(CallbackContext value)
	{
		if (value.performed)
		{
			zoomInput = value.ReadValue<float>() / 120.0f; ;
		}
	}
	public void CameraMove(CallbackContext value)
	{
		if (value.performed)
		{
			moveDirectionInput = value.ReadValue<Vector2>();
		}
	}

	public void CameraSpeedUp(CallbackContext value)
	{
		speed = HandleInput(value, speed, fastSpeed, normalSpeed);
	}

	public void CameraRotateRight(CallbackContext value)
	{
		rotateInput = HandleInput(value, rotateInput, 1);
	}

	public void CameraRotateLeft(CallbackContext value)
	{
		rotateInput = HandleInput(value, rotateInput, -1);
	}

	public void MoveToSelection(CallbackContext value)
	{
		if (value.performed)
		{
			if (Selection.isPointerOverSelectable)
			{
				newPosition = Selection.instance.GetSelectable().transform.position;
			}
		}
	}

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
