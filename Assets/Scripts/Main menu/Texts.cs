using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Texts : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    void Update()
    {
        GetTimerText(timerText);

    }
    void GetTimerText(TMP_Text timerText)
    {
        if (timerText)
        {
            Save_manager.Basic basic = Save_manager.Instance.basic;

            float t = basic.bestTime;

            //string minutes = ((int)t / 60).ToString();
            //string seconds = (t % 60).ToString("f2");
            timerText.text = basic.bestTime.ToString(); //minutes + ":" + seconds;
        }
    }
}
