using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityControl : MonoBehaviour
{
    void Update()
    {
        // Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex,false);
        Debug.Log("Quality Index:"+ QualitySettings.GetQualityLevel());
    }

    
}
