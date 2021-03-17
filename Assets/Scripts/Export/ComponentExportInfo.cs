using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentExportInfo
{
	public Vector3 position;
	public Vector3 eulerAngles;
	public string definitionName;
	public int variant;

	public ComponentExportInfo(Vector3 position, Vector3 eulerAngles, string definitionName, int variant)
	{
		this.position = position;
		this.eulerAngles = eulerAngles;
		this.definitionName = definitionName;
		this.variant = variant;
	}
}
