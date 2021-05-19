using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] 
    private GameObject go;

    [SerializeField] 
    private Text speedLabel;

    private Rigidbody target;

    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = go.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 3.6f to convert to kilometers
        speed = target.velocity.magnitude * 3.6f;

        speedLabel.text = ((int) speed) + "km/h";
    }
}
