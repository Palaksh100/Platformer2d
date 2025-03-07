using UnityEngine;
using TMPro;

public class StopwatchDisplay : MonoBehaviour
{   TMP_Text TimeText;
    void Awake()
    {
        TimeText=GetComponent<TMP_Text>();
    }
    void Update()
    {
        float time=Time.timeSinceLevelLoad;
        int Minutes=Mathf.FloorToInt(time/60);
        int Seconds=Mathf.FloorToInt(time%60);
        TimeText.text=string.Format("{0:00}:{1:00}",Minutes,Seconds);
    }
}
