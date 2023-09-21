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
    public TextMeshProUGUI FilesText;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ck.files++;
        Destroy(gameObject);
        if (ck.files == 3)
        {
            FinalDoor.SetActive(false);
            SecretDoor.SetActive(false);
        }
    }
    public void Update()
    {
        FilesText.text = "Files Collected: " + ck.files ;
    }
}
