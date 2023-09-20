using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPConsumable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided");
            
            EMPCount _emp = other.GetComponent<EMPCount>();
            Debug.Log(" Fetched");

            if (_emp != null)
            {
                _emp.EMPs += 1;
                Destroy(gameObject);
            }
        }
        
    }
}
