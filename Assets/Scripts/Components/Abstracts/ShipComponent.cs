using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
	[HideInInspector]
	public ShipCharacterController characterController; //move to new shipcomponetChil class pr something
	[HideInInspector]
	public Rigidbody shipRigidbody => GetComponent<Rigidbody>();
	[HideInInspector]
	public Collider shipCollider => GetComponentInChildren<Collider>();

	public Renderer shipRenderer => GetComponentInChildren<Renderer>();

	public int visualId;
	public string folderRoot;


	[ContextMenu("Remove")]
	public void RemoveFromControl()
	{
		characterController.RemoveComponent(this);
	}

	public void ChangeLayerAfterWait()
	{
		StartCoroutine(WaitAndChangeLayer());
	}

	IEnumerator WaitAndChangeLayer()
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.layer = 0;
	}
}
