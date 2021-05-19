using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldTriggerPlateScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject forceField;

    private void OnTriggerEnter(Collider other)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*0.5f, transform.localScale.z);
        FindObjectOfType<AudioManager>().Play("ForceField");
        FindObjectOfType<AudioManager>().Play("Switch");
        forceField.SetActive(false);
    }
    
    private void OnTriggerExit(Collider other)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*2.0f, transform.localScale.z);
        FindObjectOfType<AudioManager>().Play("ForceField");
        FindObjectOfType<AudioManager>().Play("Switch");
        forceField.SetActive(true);
    }
}
