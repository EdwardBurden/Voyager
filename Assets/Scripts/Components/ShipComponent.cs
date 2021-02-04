using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
	[HideInInspector]
	public ControlSC shipControl;
	[HideInInspector]
	public Rigidbody shipRigidbody;
	protected Collider shipCollider;

	protected void Awake()
	{
		shipRigidbody = GetComponent<Rigidbody>();
	}

	[ContextMenu("Remove")]
    public void RemoveFromControl()
    {
        shipControl.RemoveComponent(this);
    }
}
