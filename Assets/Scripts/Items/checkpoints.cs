using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour
{
    public GameObject spwnpoint;
    public checkpoints ck;
    public int files;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ck.spwnpoint = this.gameObject;
        
        //when player dies this, spwnpoint will be where they should spawn
    }
}