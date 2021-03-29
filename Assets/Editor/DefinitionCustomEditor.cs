using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShipComponentDefinition))]
public class DefinitionCustomEditor : Editor
{
	private Type[] _implementations;
	private int _implementationTypeIndex;


	SerializedProperty requirements;

	void OnEnable()
	{
		requirements = serializedObject.FindProperty("requirements");
	}

	public override void OnInspectorGUI()
	{
		ShipComponentDefinition shipComponentDefinition = target as ShipComponentDefinition;

		if (_implementations == null || GUILayout.Button("Refresh implementations"))
		{
			//this is probably the most imporant part:
			//find all implementations of INode using System.Reflection.Module
			_implementations = GetImplementations<RequirementDefinition>().Where(impl => !impl.IsSubclassOf(typeof(UnityEngine.Object))).ToArray();
		}

		EditorGUILayout.LabelField($"Found {_implementations.Count()} implementations");

		//select implementation from editor popup
		_implementationTypeIndex = EditorGUILayout.Popup(new GUIContent("Implementation"),
			_implementationTypeIndex, _implementations.Select(impl => impl.FullName).ToArray());

		if (GUILayout.Button("Create instance"))
		{
			//set new value
			shipComponentDefinition.requirements.Add((RequirementDefinition)Activator.CreateInstance(_implementations[_implementationTypeIndex]));
		}

		base.OnInspectorGUI();

	}


	private static Type[] GetImplementations<T>()
	{
		var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());

		var interfaceType = typeof(T);
		return types.Where(p => interfaceType.IsAssignableFrom(p) && !p.IsAbstract).ToArray();
	}
}
