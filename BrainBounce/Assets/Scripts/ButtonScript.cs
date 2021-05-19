using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] 
    private  GameObject target;
    
    [SerializeField] 
    private  Material offMaterial;
    [SerializeField] 
    private  Material onMaterial;

    [SerializeField] 
    private  bool on;
    private bool cooldown = false;

    void ResetCooldown(){
        cooldown = false;
    }
    
    private void Awake()
    {
        if (on)
        {
            gameObject.GetComponent<MeshRenderer>().material = onMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = offMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( cooldown == false ) {
            Invoke("ResetCooldown",0.2f);
            cooldown = true;
        }
        else
        {
            return;
        }
        
        FindObjectOfType<AudioManager>().Play("Switch");
        if (on)
        {
            on = false;
            gameObject.GetComponent<MeshRenderer>().material = offMaterial;
        }
        else
        {
            on = true;
            gameObject.GetComponent<MeshRenderer>().material = onMaterial;
        }

        if (target.activeSelf)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
        
        FindObjectOfType<AudioManager>().Play("ForceField");
    }
}
