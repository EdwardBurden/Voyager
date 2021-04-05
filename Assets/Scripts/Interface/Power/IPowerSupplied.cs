using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerSupplied 
{
	bool CanPowerComponent(int powerRequired);
	void PowerComponent(int powerRequired);
}
