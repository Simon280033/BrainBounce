using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour
{
    [SerializeField] 
    private float blastRadius;
    [SerializeField] 
    private float explosionForce;
    
    private Collider[] hitColliders;

    [SerializeField] 
    private GameObject explosionVFX;

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.contacts[0].point.ToString());
        if (col.collider.material.bounciness != 1)
        {
            if (col.gameObject.CompareTag("Pipe Enter"))
            {
                Destroy(col.gameObject);
            } else if (col.gameObject.CompareTag("Pipe Exit"))
            {
                
            }
            else
            {
                DoExplosion(col.contacts[0].point);
            }
        }
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);

        foreach (Collider hitcol in hitColliders)
        {
            Debug.Log(hitcol.gameObject.name);
            if (hitcol.GetComponent<Rigidbody>() != null)
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, blastRadius, 1.0f, ForceMode.Impulse);
            }
        }

        ShowExplosion();
        FindObjectOfType<AudioManager>().Play("RocketExplode");
        Destroy (gameObject);
    }

    private void ShowExplosion()
    {
        GameObject go = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(go, 2.0f); //Destroy after 2 seconds.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
