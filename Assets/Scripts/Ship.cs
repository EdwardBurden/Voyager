using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	[Min(1)]
	public float torqueAmount = 100;

	Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody.AddTorque(this.transform.forward * torqueAmount, ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rigidbody.AddTorque(-this.transform.forward * torqueAmount, ForceMode.Force);
		}
	}

}
