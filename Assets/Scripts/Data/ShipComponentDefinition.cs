using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Definitions/ShipComponent")]
public class ShipComponentDefinition : ScriptableObject
{
	public ShipComponent[] prefabVariants;
	public string folderRoot;
	public string displayName;
	public Image displayIcon;
	public ComponentDisplayCategory displayCategory;
	public string description;
	[SerializeReference]
	public List<RequirementDefinition> requirements;
	[SerializeReference]
	public List<EffectDefinition> effects;
}
