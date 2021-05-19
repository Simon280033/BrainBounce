using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGrenadeWallScript : MonoBehaviour
{
    [SerializeField] 
    private  GameObject zapVFX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grenade"))
        {
            FindObjectOfType<AudioManager>().Play("GrenadeGone");
            GameObject go = Instantiate(zapVFX, other.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(go, 2.0f); //Destroy after 2 seconds.
        } 
    }
}
