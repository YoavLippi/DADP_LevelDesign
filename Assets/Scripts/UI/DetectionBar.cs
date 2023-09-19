using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public EnemyDetection EnemyDetection;
    public Image HealthMask;
    


    void Update()
    {
        GetCurrentFill(HealthMask,EnemyDetection.EnemyDetectionAmt);
    }

    void GetCurrentFill(Image mask, float attributeValue)
    {
        float fillAmount = attributeValue / maximum;
        mask.fillAmount = fillAmount;
    }
}
