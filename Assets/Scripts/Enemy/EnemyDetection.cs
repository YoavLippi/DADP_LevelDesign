using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int EnemyDetectionAmt = 100;
    public GameObject endpanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "Collision") 
        {
            EnemyDetectionAmt -= 50;
        }
        if (EnemyDetectionAmt>=0)
        {
            endpanel.SetActive(true);
        }
       
    }
}
