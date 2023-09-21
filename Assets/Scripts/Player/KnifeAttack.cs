using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public bool attacking;
    private void OnTriggerEnter(Collider other)
    {
        if (!attacking) return;
        if (other.CompareTag("Enemy"))
        {
           Destroy(other.gameObject);
        }
    }
}
