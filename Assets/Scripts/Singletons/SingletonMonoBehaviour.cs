﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = (T)FindObjectOfType(typeof(T));
				if (_instance == null)
				{
					var singletonObject = new GameObject();
					_instance = singletonObject.AddComponent<T>();
					singletonObject.name = typeof(T).ToString() + " (Singleton)";
					DontDestroyOnLoad(singletonObject);
				}
			}

			return _instance;
		}

	}
}
