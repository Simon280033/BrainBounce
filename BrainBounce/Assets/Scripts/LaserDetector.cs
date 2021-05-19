using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetector : MonoBehaviour
{
    [SerializeField] 
    private GameObject LaserEmittor;

    public void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(LaserEmittor.transform.position, LaserEmittor.transform.forward, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                print("Hit: " + hit.collider.gameObject.name);
                FindObjectOfType<AudioManager>().Play("LaserHit");
                
                hit.collider.transform.SetParent(null); // Stops sticking to platform
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(-hit.collider.transform.forward * 30, ForceMode.Impulse);
            }
        }
    }
}
