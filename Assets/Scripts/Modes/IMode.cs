using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMode
{
	bool isActive { get; set; }
	void BeginMode();
	void EndMode();
}
