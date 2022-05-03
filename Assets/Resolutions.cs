using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Resolutions : MonoBehaviour
{
    public TMP_Dropdown resolution_dropdown;

    Resolution[] resolutions;

    public string currentResolution;

    public TMP_Text resolutionText;
    public TMP_Text displayModeText;
    void Start()
    {
        if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects") && Directory.Exists(Application.persistentDataPath + "/Basic") && Directory.Exists(Application.persistentDataPath + "/Powerups"))
        {
            if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat") && File.Exists(Application.persistentDataPath + "/Basic/Basic.dat") && File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
            {
                resolutions = Screen.resolutions;
                resolution_dropdown.ClearOptions();

                List<string> options = new List<string>();

                int currentResolutionIndex = 0;
                for (int i = 0; i < resolutions.Length; i++)
                {
                    string option = resolutions[i].width + " x " + resolutions[i].height;
                    options.Add(option);
                    currentResolution = option.ToString();
                    resolutionText.text = "Your system: " + currentResolution + " with " + resolutions[i].refreshRate + "HZ";
                    displayModeText.text = "Fullscreen (Borderless)";
                    if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = i;
                    }
                    UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.gameObject, true);
                    UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                        .text = "Resolution set at " + resolutions[i].width + " x " + resolutions[i].height; 
                }

                resolution_dropdown.AddOptions(options);
                resolution_dropdown.value = currentResolutionIndex;
                resolution_dropdown.RefreshShownValue();
                
            }
            else
            {
                Debug.LogError("There was a problem during this action");
            }
        }
        else
        {
            Debug.LogError("There was a problem during this action");
        }
    }

    public void setResolution(int resloutionIndex)
    {
        for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
        {
            if (Audio_manager.Instance.ASources[i] != null)
            {
                Resolution resloution = resolutions[resloutionIndex];
                Screen.SetResolution(resloution.width, resloution.height, FullScreenMode.FullScreenWindow);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.gameObject, true);
                UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                    .text = "Resolution set at " + resloution.width + " x " + resloution.height + " Display mode: Fullscreen borderless";
                displayModeText.text = "Display mode: " + "Fullscreen (Borderless)";
                Debug.Log("Resolution set at " + resloution.width + " x " + resloution.height + " Display mode: Fullscreen borderless");
                Debug.Log("Display mode set at: " + "Full screen (Borderless)");
                Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
            }
            else 
            { 
                Debug.LogError("Audio sources is not found");
           }
        }
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.gameObject, true);

        if (isFullscreen == true)
        {
            for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
            {
                if (Audio_manager.Instance.ASources[i] != null)
                {
                    Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                    UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
.text = "Display mode set at: Fullscreen";
                    displayModeText.text = "Display mode: " + "Fullscreen";
                    Debug.Log("Display mode set at: Fullscreen");
                }
                else
                {
                    Debug.LogError("Audio sources is not found");
                }
            }
        }
        else
        {
            for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
            {
                if (Audio_manager.Instance.ASources[i] != null)
                {
                    Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                    UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
.text = "Display mode set at: Window";
                    displayModeText.text = "Display mode: " + "Window";
                    Debug.Log("Display mode set at: Window");
                }
                else
                {
                    Debug.LogError("Audio sources is not found");
                }
            }
        }
    }
}
