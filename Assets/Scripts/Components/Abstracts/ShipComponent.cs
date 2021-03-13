using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
	public int xSize;
	public int zSize;

	public GameObject interior;
	public GameObject exterior;

	[HideInInspector]
	public ShipCharacterController characterController; //move to new shipcomponetChil class pr something
	[HideInInspector]
	public Rigidbody shipRigidbody => GetComponent<Rigidbody>();
	[HideInInspector]
	public Collider shipCollider => GetComponentInChildren<Collider>();

	public Renderer shipRenderer => GetComponentInChildren<Renderer>();



	public int visualId;
	public string folderRoot;

	public void OnBuild()
	{
		if (interior != null)
		{
			interior.SetActive(true);

			exterior.SetActive(false);
		}
		
	}

	public void OnFlight()
	{
		if (interior != null)
		{
			interior.SetActive(false);

			exterior.SetActive(true);
		}
	}


	[ContextMenu("Remove")]
	public void RemoveFromControl()
	{
		ShipConstructor.RemoveComponent(this, characterController);
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
