using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCatcherScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject zapVFX;

    [SerializeField] 
    private GameObject cube;

    [SerializeField] 
    private Vector3 respawnCoordinates;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LightCube"))
        {
            FindObjectOfType<AudioManager>().Play("CubeSpawn");
            GameObject go = Instantiate(zapVFX, respawnCoordinates, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Instantiate(cube, respawnCoordinates, Quaternion.identity);
            Destroy(go, 2.0f); //Destroy after 2 seconds.
        } 
    }
}
