using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EMPCount : MonoBehaviour
{
    public int EMPs = 0;
    public TextMeshProUGUI EMPText;
    
    void Update()
    {
        EMPText.text = "EMPs : " + EMPs ;
    }
    
}
