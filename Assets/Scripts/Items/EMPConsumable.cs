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
            //Add a method to increase EMP count for player
            Destroy(gameObject);
        }
    }
}
