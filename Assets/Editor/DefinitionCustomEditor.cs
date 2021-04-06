using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShipComponentDefinition))]
public class DefinitionCustomEditor : Editor
{
	private Type[] requirementTypes;
	private Type[] effectTypes;
	private int requirementTypeIndex;
	private int effectTypeIndex;

	public override void OnInspectorGUI()
	{
		ShipComponentDefinition shipComponentDefinition = target as ShipComponentDefinition;

		if (requirementTypes == null || effectTypes == null || GUILayout.Button("Refresh implementations"))
		{
			requirementTypes = GetImplementations<RequirementDefinition>().Where(impl => !impl.IsSubclassOf(typeof(UnityEngine.Object))).ToArray();
			effectTypes = GetImplementations<EffectDefinition>().Where(impl => !impl.IsSubclassOf(typeof(UnityEngine.Object))).ToArray();
		}

		EditorGUILayout.BeginHorizontal();
		requirementTypeIndex = EditorGUILayout.Popup(new GUIContent("Select Requirement"), requirementTypeIndex, requirementTypes.Select(impl => impl.FullName).ToArray());

		if (GUILayout.Button("Create Requirement"))
		{
			//set new value
			shipComponentDefinition.requirements.Add((RequirementDefinition)Activator.CreateInstance(requirementTypes[requirementTypeIndex]));
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		effectTypeIndex = EditorGUILayout.Popup(new GUIContent("Select Effect"), effectTypeIndex, effectTypes.Select(impl => impl.FullName).ToArray());

		if (GUILayout.Button("Create Effect"))
		{
			//set new value
			shipComponentDefinition.effects.Add((EffectDefinition)Activator.CreateInstance(effectTypes[effectTypeIndex]));
		}
		EditorGUILayout.EndHorizontal();
		base.OnInspectorGUI();

	}


	private static Type[] GetImplementations<T>()
	{
		var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());

		var interfaceType = typeof(T);
		return types.Where(p => interfaceType.IsAssignableFrom(p) && !p.IsAbstract).ToArray();
	}
}
