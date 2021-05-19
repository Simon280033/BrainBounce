using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BounceSoundPlay : MonoBehaviour
{
    [SerializeField] 
    private AudioSource bounceSound; // We emit the sound from the object instead of audiomanager, so we don't have to hear the bounce sound constantly
    private void OnCollisionEnter(Collision other)
    {
        bounceSound = GetComponent<AudioSource>();
        bounceSound.Play(0);
    }
}
