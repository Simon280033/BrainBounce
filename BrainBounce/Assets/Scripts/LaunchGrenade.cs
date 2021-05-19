using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LaunchGrenade : MonoBehaviour
{
    [SerializeField] 
    private GameObject grenadePrefab;
    [SerializeField] 
    private float propulsionForce;

    private Transform myTransform;
    
    private bool cooldown = false;

    void ResetCooldown(){
        cooldown = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        setInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !cooldown && Time.timeScale == 1f)
        {
            Invoke("ResetCooldown",0.3f);
            cooldown = true;
            SpawnGrenade();
        }
    }

    void SpawnGrenade()
    {
        
        FindObjectOfType<AudioManager>().Play("RocketLaunch");
        
        GameObject grenade = (GameObject) Instantiate(grenadePrefab, myTransform.transform.TransformPoint(0.1f, 0, 1f), myTransform.rotation); 
        grenade.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);
        Destroy(grenade, 10);
    }
    void setInitialReferences()
    {
        myTransform = transform;
    }
}
