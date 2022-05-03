using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_settings : MonoBehaviour
{
    public void Buttons(string name)
    {
        switch (name)
        {
            case "Controls":
                if (!UI_manager.Instance.Input_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Input_panel, true);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, false);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
            case "Audio":
                if (!UI_manager.Instance.Audio_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Audio_panel, true);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, false);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
            case "Resolution":
                if (!UI_manager.Instance.Resolution_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Resolution_panel, true);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, false);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
        }
    }
    public void QuitButtons(string name)
    {
        switch (name)
        {
            case "Controls":
                if (UI_manager.Instance.Input_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Input_panel, false);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, true);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
            case "Audio":
                if (UI_manager.Instance.Audio_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Audio_panel, false);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, true);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
            case "Resolution":
                if (UI_manager.Instance.Resolution_panel.activeInHierarchy)
                {
                    foreach (AudioSource item in Audio_manager.Instance.ASources)
                    {
                        if (item != null)
                        {
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Resolution_panel, false);
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, true);
                        }
                        else
                        {
                            Debug.LogError("Audio source not found");
                        }
                    }
                }
                break;
        }
    }
}
