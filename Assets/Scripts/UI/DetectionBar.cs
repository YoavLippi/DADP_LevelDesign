using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public PlayerDetectionInfo _PlayerDetectionInfo;
    public Image HealthMask;
    


    void Update()
    {
        GetCurrentFill(HealthMask, _PlayerDetectionInfo.PlayerDetectionAmt);
    }

    void GetCurrentFill(Image mask, float attributeValue)
    {
        float fillAmount = attributeValue / maximum;
        mask.fillAmount = fillAmount;
    }
}
