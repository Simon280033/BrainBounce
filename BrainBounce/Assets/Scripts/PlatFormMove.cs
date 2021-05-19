using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatFormMove : MonoBehaviour
{
    private Vector3 target;
    
    [SerializeField] 
    private float destinationX;
    
    private Vector3 dirNormalized;


    void Start ()
    {
        target = new Vector3(destinationX, transform.position.y, transform.position.z);
        dirNormalized = (target - transform.position).normalized;

        StartCoroutine(BoxMoveCoroutine());
    }


    IEnumerator BoxMoveCoroutine ()
    {
        while (!(Vector3.Distance(target, transform.position) <= 1))
        {
            transform.position = transform.position + dirNormalized * 4 * Time.deltaTime;
            yield return null;

        }
        
        print("Reached the target.");

        yield return new WaitForSeconds(3f);

        print("BoxMoveCoroutine is now finished.");
    }
    
    public void OnCollisionEnter(Collision other)
    {
        other.collider.transform.SetParent(transform);
    }

    public void OnCollisionExit(Collision other)
    {
        other.collider.transform.SetParent(null);
    }
}
