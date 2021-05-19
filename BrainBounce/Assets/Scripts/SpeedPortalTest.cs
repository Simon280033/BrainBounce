using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPortalTest : MonoBehaviour
{
    [SerializeField] 
    private GameObject objectTestingFor;
    [SerializeField] 
    private Material openMaterial;
    [SerializeField] 
    private Material closedMaterial;
    [SerializeField] 
    private float openForXSecs;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object hit with: " + other.GetComponent<Rigidbody>().velocity.magnitude * 3.6f + "km/h");
        Debug.Log("Tag: " + other.gameObject.tag);
        if (other.GetComponent<Rigidbody>().velocity.magnitude * 3.6f > 50 && !(other.gameObject.CompareTag("Grenade")))
        {
            OpenPortal();
            
            Invoke("ClosePortal", openForXSecs);
        } 
    }

    private void OpenPortal()
    {
        FindObjectOfType<AudioManager>().Play("PortalOpen");
        objectTestingFor.GetComponent<Collider>().enabled = false;
        objectTestingFor.GetComponent<MeshRenderer>().material = openMaterial;
    }

    private void ClosePortal()
    {
        objectTestingFor.GetComponent<Collider>().enabled = true;
        objectTestingFor.GetComponent<MeshRenderer>().material = closedMaterial;
    }
}
