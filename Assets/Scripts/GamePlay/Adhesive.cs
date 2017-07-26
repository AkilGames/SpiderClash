using System.Collections.Generic;
using UnityEngine;

public class Adhesive : MonoBehaviour
{ 
    public GameObject myJoint;
    private List<GameObject> tlist = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tlist.Exists((obj) => obj == collision.gameObject))
        {
            GameObject joint = Instantiate<GameObject>(myJoint, collision.contacts[0].point, Quaternion.identity, transform);
            joint.GetComponent<MyJoint>().Lock(collision.rigidbody);
            tlist.Add(collision.gameObject);
        }
    }
}