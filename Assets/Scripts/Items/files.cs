using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class files : MonoBehaviour
{
    public checkpoints ck;
    public SceneLoader _SceneLoader;
    public TextMeshProUGUI FilesText;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ck.files++;
        Destroy(gameObject);
        if (ck.files == 3)
        {
            _SceneLoader.LoadEndScene();   
        }
    }
    public void Update()
    {
        FilesText.text = "Files Collected: " + ck.files ;
    }
}
