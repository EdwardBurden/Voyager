using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentExportInfo
{
	public Vector3 position;
	public Vector3 eulerAngles;
	public int componentId;

	public ComponentExportInfo(Vector3 position, Vector3 eulerAngles, int componentId)
	{
		this.position = position;
		this.eulerAngles = eulerAngles;
		this.componentId = componentId;
	}
}
