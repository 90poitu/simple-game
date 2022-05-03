using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : MonoBehaviour
{
    public void Socials(string name)
    {
        switch (name)
        {
            case "Discord":
                Debug.Log("Discord link here");
                break;
            case "Website":
                Debug.Log("Website link here");
                break;
            case "Instagram":
                Debug.Log("Instagram link here");
                break;
        }
    }
}
