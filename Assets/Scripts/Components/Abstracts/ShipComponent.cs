using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	internal bool status;

	[HideInInspector]
	public Rigidbody shipRigidbody => GetComponent<Rigidbody>();
	[HideInInspector]
	public Collider shipCollider => GetComponentInChildren<Collider>();
	public Renderer shipRenderer => GetComponentInChildren<Renderer>();

	public void Init(ShipComponentDefinition shipComponentDefinition, int variant)
	{
		definition = shipComponentDefinition;
		this.variant = variant;
		status = true;
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

	internal ShipComponentDefinition GetDefinition()
	{
		return definition;
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

	internal List<RequirementDefinition> GetDefinitionRequirements()
	{
		return definition.requirements;
	}
	internal PowerRequirementDefinition GetPowerRequirement()
	{
		List<RequirementDefinition> requirements = GetDefinitionRequirements();
		if (requirements == null || requirements.Count == 0)
		{
			return null;
		}
		return requirements.FirstOrDefault(req => req is PowerRequirementDefinition) as PowerRequirementDefinition;

	}
}
