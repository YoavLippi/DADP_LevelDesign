using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public SceneLoader _SceneLoader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCollision"))
        {
            Debug.Log(other.gameObject.tag);
            Cursor.lockState = CursorLockMode.None;
            _SceneLoader.LoadEndScene();        
        }
    }
}
