using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartingPageSocialMedia : MonoBehaviour
{
    [SerializeField] private GameObject Alert_panel;
    public void SocialMedia(string name)
    {
        string message = "Follow me to get the latest updates from this game";
        switch (name)
        {
            case "Discord":
                if (!Alert_panel.activeInHierarchy) {
                    Alert_panel.SetActive(true);
                Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = message;
        }
                break;
            case "Instagram":
                if (!Alert_panel.activeInHierarchy)
                {
                    Application.OpenURL("https://www.instagram.com/postionv/");
                    Alert_panel.SetActive(true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = message;
                }
                break;
            case "Website":
                if (!Alert_panel.activeInHierarchy)
                {
                    Application.OpenURL("https://positionvs-wondrous-project.webflow.io/");
                    Alert_panel.SetActive(true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = message;
                }
                break;
        }
    }
    public void Quit()
    {
        if (Alert_panel.activeInHierarchy)
        {
            Alert_panel.SetActive(false);
        }
    }
}
