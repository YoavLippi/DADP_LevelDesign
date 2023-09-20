using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidden : MonoBehaviour
{
    public GameObject hiddendoor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        hiddendoor.SetActive(false);
    }
}
