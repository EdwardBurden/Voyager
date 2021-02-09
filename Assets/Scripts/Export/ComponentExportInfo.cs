using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentExportInfo
{
	public Vector3 position;
	public Vector3 eulerAngles;
	public string folder;
	public int componentId;
	public int versionId;

	public ComponentExportInfo(Vector3 position, Vector3 eulerAngles, int componentId, int visualId, string folder)
	{
		this.position = position;
		this.eulerAngles = eulerAngles;
		this.componentId = componentId;
		this.versionId = visualId;
		this.folder = folder;
	}
}
