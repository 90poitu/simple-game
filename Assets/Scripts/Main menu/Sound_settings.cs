using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class Sound_settings : MonoBehaviour
{
    public GameObject audioSourceOBJ;
    public GameObject Alert_panel;
    public Slider Volume_adjectment_slider;
    public TMP_Text Volume_text;
    void Update()
    {
        if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects"))
        {
            if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat"))
            {
                if (Save_manager.Instance.ui_sound_effects.sound_vfx == 0)
                {
                    Volume_text.text = "OFF";
                    Volume_adjectment_slider.value = Save_manager.Instance.ui_sound_effects.sound_vfx;
                }
                else
                {
                    Volume_text.text = Save_manager.Instance.ui_sound_effects.sound_vfx.ToString("n1");
                    Volume_adjectment_slider.value = Save_manager.Instance.ui_sound_effects.sound_vfx;
                }
            }
            else
            {
                Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
            }
        }
        else
        {
            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
        }
    }
    public void Sound(float amount)
    {
        switch (amount)
        {
            case 0f:
                if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects"))
                {
                    if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat")) 
                    {
                        if (Save_manager.Instance.ui_sound_effects.sound_vfx != 0f)
                        {
                            Save_manager.Instance.ui_sound_effects.sound_vfx = 0f;
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "Volume is set to " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                            audioSourceOBJ.GetComponent<Audio_manager>().playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                        }
                        else
                        {
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "You already set the volume at " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                        }
                    }
                    else
                    {
                        UI_manager.Instance.Enable_Disable(Alert_panel, true);
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    UI_manager.Instance.Enable_Disable(Alert_panel, true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                }
                break;
            case 0.5f:
                if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects"))
                {
                    if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat"))
                    {
                        if (Save_manager.Instance.ui_sound_effects.sound_vfx != 0.5f)
                        {
                            Save_manager.Instance.ui_sound_effects.sound_vfx = 0.5f;
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "Volume is set to " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                            audioSourceOBJ.GetComponent<Audio_manager>().playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                        }
                        else
                        {
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "You already set the volume at " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                        }
                    }
                    else
                    {
                       UI_manager.Instance.Enable_Disable(Alert_panel, true);
                       Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                   UI_manager.Instance.Enable_Disable(Alert_panel, true);
                   Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                }
                break;

            case 1f:
                if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects"))
                {
                    if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat"))
                    {
                        if (Save_manager.Instance.ui_sound_effects.sound_vfx != 1f)
                        {
                            Save_manager.Instance.ui_sound_effects.sound_vfx = 1f;
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "Volume is set to " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                            audioSourceOBJ.GetComponent<Audio_manager>().playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                        }
                        else
                        {
                            UI_manager.Instance.Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "You already set the volume at " + Save_manager.Instance.ui_sound_effects.sound_vfx;
                        }
                    }
                    else
                    {
                        UI_manager.Instance.Enable_Disable(Alert_panel, true);
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    UI_manager.Instance.Enable_Disable(Alert_panel, true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text = "There was a problem during this action. Please relog";
                }
                break;
        }
    }
}
