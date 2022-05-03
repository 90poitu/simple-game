using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pause : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameUI gameUI;
    void Update()
    {
        GetTimerText(timerText);
    }
    void GetTimerText(TMP_Text timerText)
    {
            float t = Time.time - gameUI.startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;

            if (timerText)
            {
                timerText.text = minutes + ":" + seconds;
            }
    }
}
