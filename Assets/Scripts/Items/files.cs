using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class files : MonoBehaviour
{
    public checkpoints ck;
    public GameObject FinalDoor;
    public GameObject SecretDoor;
    public GameObject lastDoor;
    public TextMeshProUGUI FilesText;
    
    // Start is called before the first frame update
    public void Update()
    {
        FilesText.text = "Files Collected: " + ck.files ;
    }
    private void OnTriggerEnter(Collider other)
    {
        ck.files++;
        if (ck.files == 3)
        {
            FinalDoor.SetActive(false);
            SecretDoor.SetActive(false);
            lastDoor.SetActive(true);
        }
        Destroy(gameObject);
    }

}
