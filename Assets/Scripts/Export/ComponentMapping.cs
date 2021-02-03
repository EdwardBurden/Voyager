using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentMapping
{
	private static Dictionary<int, Type> mapping = new Dictionary<int, Type>()
	{
		{ 0 , typeof(ShipControlComponent) },
		{ 1 , typeof(ShipComponentHallway) },
		{ 2 , typeof(DamageComponent) }
	};

	public static int GetIntFromType(Type type)
	{
		if (!mapping.ContainsValue(type))
		{
			throw new Exception("Type Not found");
		}

		return mapping.FirstOrDefault(x => x.Value == type).Key;
	}

	public static Type GetTypeFromInt(int id)
	{
		if (!mapping.TryGetValue(id, out Type type))
		{
			throw new Exception("Type Not found");
		}


		return type;
	}
}
