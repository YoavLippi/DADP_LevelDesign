using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int EnemyDetectionAmt = 100;
    public SceneLoader _sceneLoader;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy")) 
        {
            EnemyDetectionAmt -= 50;
        }
        if (EnemyDetectionAmt<=0)
        {
            _sceneLoader.LoadEndScene();
        }
       
    }
}
