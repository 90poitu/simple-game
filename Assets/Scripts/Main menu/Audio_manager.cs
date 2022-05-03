using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    public static Audio_manager Instance;
    public AudioSource[] ASources;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void playSound(string name, float db)
    {
        switch (name)
        {
            case "Enter":
                if (ASources[0] != null)
                {
                    ASources[0].volume = db;
                    ASources[0].Play();
                }
                break;
            case "Hover":
                if (ASources[1] != null)
                {
                    ASources[1].volume = db;
                    ASources[1].Play();
                }
                break;
        }
    }
}
