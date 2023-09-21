using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    public float radius = 10f; 
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
                hitObject.GetComponent<aidetection>().enabled = false; 
                hitObject.GetComponent<botmovement>().enabled = false;
                StartCoroutine(EnableScriptsAfterDelay(hitObject));
            }

            if (hitObject.CompareTag("BreakableDoor"))
            {
                Destroy(hitObject);    
            }
        }
        
        StartCoroutine(DestroyAfterDelay(3.5f));
    }

    private IEnumerator EnableScriptsAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        
        obj.GetComponent<aidetection>().enabled = true; 
        obj.GetComponent<botmovement>().enabled = true; 
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); 
    }
}