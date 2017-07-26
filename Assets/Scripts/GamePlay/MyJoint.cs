using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJoint : MonoBehaviour
{
    public FixedJoint2D join;

    public void Lock(Rigidbody2D with)
    {
        join.connectedBody = with;
        join.anchor = with.tag == "Player" ? new Vector2(0.2f, 0.0f) : new Vector2(2.0f, 0.0f);
    }
}
