using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] 
    private float rotationsPerMinute;
    void Update()
    {
        transform.Rotate(0f,6.0f*rotationsPerMinute*Time.deltaTime,0f);
    }
}
