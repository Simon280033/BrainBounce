using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcherScript : MonoBehaviour
{
    [SerializeField] 
    private Vector3 respawnCoordinates;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = respawnCoordinates;
            FindObjectOfType<AudioManager>().Play("Respawn");
        } 
    }
}
