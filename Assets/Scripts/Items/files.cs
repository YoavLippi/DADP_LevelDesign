using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class files : MonoBehaviour
{
    public checkpoints ck;
    public GameObject SecretDoor;
    public GameObject Keydoor1;
    public GameObject Keydoor2;
    public GameObject FinalDoor;
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
            SecretDoor.SetActive(false);
            Keydoor1.SetActive(false);
            Keydoor2.SetActive(false);
            FinalDoor.SetActive(true);
        }
        Destroy(gameObject);
    }

}
