using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnTrigger : MonoBehaviour
{
    [SerializeField] 
    private  Vector3 cubeCoordinates;
    [SerializeField] 
    private  GameObject cube;
    [SerializeField] 
    private  GameObject zapVFX;

    private  GameObject madeCube;
    
    private void OnTriggerEnter(Collider other)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*0.5f, transform.localScale.z);

        FindObjectOfType<AudioManager>().Play("CubeSpawn");
        GameObject spawned = Instantiate(zapVFX, cubeCoordinates, Quaternion.identity) as GameObject;

        if (madeCube != null)
        {
            GameObject destroyed = Instantiate(zapVFX, madeCube.transform.position, Quaternion.identity) as GameObject;
            Destroy(madeCube);
            Destroy(destroyed, 2.0f); //Destroy after 2 seconds.
        }
        Destroy(spawned, 2.0f); //Destroy after 2 seconds.

        FindObjectOfType<AudioManager>().Play("Switch");
        madeCube = Instantiate(cube, cubeCoordinates, Quaternion.identity );
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*2.0f, transform.localScale.z);
    }
}
