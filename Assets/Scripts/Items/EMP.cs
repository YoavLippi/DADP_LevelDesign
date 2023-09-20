using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    public float radius = 20f;
    public LayerMask targetLayer; 

    private void Start()
    {
        Vector3 startLocation = transform.position; 
        Collider[] colliders = Physics.OverlapSphere(startLocation, radius, targetLayer);

        foreach (Collider collider in colliders)
        {
           
            GameObject hitObject = collider.gameObject;
            if (hitObject.CompareTag("Enemy"))
            {
                Destroy(hitObject);
              
                // hitObject.GetComponent<MyScript>().enabled = false; // use this to disable enemy script - walking and detection
            }

            if (hitObject.CompareTag("BreakableDoor"))
            {
                Destroy(hitObject);    
            }
        }
    }
}               

