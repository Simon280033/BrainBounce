using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        other.collider.transform.SetParent(transform);
    }

    public void OnCollisionExit(Collision other)
    {
        other.collider.transform.SetParent(null);
    }
}
