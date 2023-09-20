using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class files : MonoBehaviour
{
    public checkpoints ck;
    public GameObject endpanel;
   
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ck.files++;
        if (ck.files == 3)
        {
            endpanel.SetActive(true);
        }
    }
}
