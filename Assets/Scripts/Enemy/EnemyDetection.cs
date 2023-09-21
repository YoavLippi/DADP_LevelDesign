using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int EnemyDetectionAmt = 100;
    public SceneLoader _sceneLoader;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            EnemyDetectionAmt -= 50;
        }
        if (EnemyDetectionAmt>=0)
        {
            _sceneLoader.LoadEndScene();
        }
       
    }
}
