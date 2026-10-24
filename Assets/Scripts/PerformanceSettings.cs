using UnityEngine;

public class PerformanceSettings : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}