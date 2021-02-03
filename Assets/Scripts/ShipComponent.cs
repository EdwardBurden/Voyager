using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
    public ShipControlComponent shipControl;
	protected Rigidbody shipRigidbody;
	protected Collider shipCollider;

    [ContextMenu("Remove")]
    public void RemoveFromControl()
    {
        shipControl.RemoveComponent(this);
    }
}
