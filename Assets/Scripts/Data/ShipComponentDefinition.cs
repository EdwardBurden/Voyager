using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Definitions/ShipComponent")]
public class ShipComponentDefinition : ScriptableObject
{
	public ShipComponent[] prefabVariants;
	public string folderRoot;
	public string displayName;
	public string description;
	[SerializeReference]
	public List<RequirementDefinition> requirements;
	[SerializeReference]
	public List<EffectDefinition> effects;
}
