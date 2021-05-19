using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;
    public AudioSource laserSound; // We emit the sound from the object instead of audiomanager, so we don't have to hear the laser sound constantly
    
    // Start is called before the first frame update
    void Start()
    {
        laserSound = GetComponent<AudioSource>();
        laserSound.Play(0);
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(1, new Vector3(0,0,100));
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0,0,hit.distance));
            }
            else
            {
                lr.SetPosition(1, new Vector3(0,0,100));
            }
        }
    }
}
