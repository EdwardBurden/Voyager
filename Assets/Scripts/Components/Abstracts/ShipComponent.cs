using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CanEditMultipleObjects]
public abstract class ShipComponent : MonoBehaviour
{
	//list/group cost (materials etc, can be used in getcostinterfacecalls)
	//list/group  requirements(powerrequirements etc)

	private ShipComponentDefinition definition;
	private int variant;

	[HideInInspector]
	public ShipCharacterController characterController; //move to new shipcomponetChil class pr something
	[HideInInspector]
	public Rigidbody shipRigidbody => GetComponent<Rigidbody>();
	[HideInInspector]
	public Collider shipCollider => GetComponentInChildren<Collider>();
	public Renderer shipRenderer => GetComponentInChildren<Renderer>();

	public void Init(ShipComponentDefinition shipComponentDefinition , int variant)
	{
		definition = shipComponentDefinition;
		this.variant = variant;
	}

	public void ChangeLayerAfterWait(int layer)
	{
		StartCoroutine(WaitAndChangeLayer(layer));
	}

	IEnumerator WaitAndChangeLayer(int layer)
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.layer = layer;
	}

	internal string GetDefinitionName()
	{
		return definition.name;
	}

	internal int GetDefinitionVariant()
	{
		return variant;
	}

	internal string GetDisplayName()
	{
		return definition.displayName;
	}
}
