using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject target;

    [SerializeField] 
    private float time;

    [SerializeField] 
    private GameObject knob;

    [SerializeField] 
    private Material onMaterial;
    [SerializeField] 
    private Material offMaterial;

    [SerializeField] 
    private AudioSource sound;

    [SerializeField] 
    private bool on;
    private bool cooldown = false;

    void ResetCooldown(){
        cooldown = false;
    }
    void Awake()
    {
        if (on)
        {
            knob.GetComponent<MeshRenderer>().material = onMaterial;
        }
        else
        {
            knob.GetComponent<MeshRenderer>().material = offMaterial;
        }
    }

    private void Reverse()
    {
        if (target.activeSelf)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
        
        if (on)
        {
            on = false;
            knob.GetComponent<MeshRenderer>().material = offMaterial;
            transform.RotateAround (transform.position, transform.forward, -270.0f);
            sound.Stop();
        }
        else
        {
            on = true;
            knob.GetComponent<MeshRenderer>().material = onMaterial;
            transform.RotateAround (transform.position, transform.forward, 270.0f);
            sound.Play();
        }
        
        FindObjectOfType<AudioManager>().Play("Switch");
        FindObjectOfType<AudioManager>().Play("ForceField");

    }

    private void OnTriggerEnter(Collider other)
    {
        if ( cooldown == false ) {
            Invoke("ResetCooldown",time);
            cooldown = true;
        }
        else
        {
            return;
        }
        
        Reverse();
        
        Invoke("Reverse", time);
        
    }
}
