using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class UI_manager : MonoBehaviour
{
    public static UI_manager Instance;

    #region [ GAMEOBJECTS ]
    public GameObject Settings_panel;
    public GameObject MainMenu_panel;
    public GameObject Alert_panel;
    public GameObject Shop_panel;
    public GameObject CharacterScreen_panel;
    public GameObject Credit_panel;
    public GameObject Input_panel;
    public GameObject Audio_panel;
    public GameObject Resolution_panel;
    #endregion

    #region [ TEXTS ]
    public TMP_Text coins_text;
    public TMP_Text heart_amount;
    #endregion

    [System.Serializable]
    public class Info
    {
        #region [ STRING ]
        [TextArea] public string helpDescription;
        #endregion
    }

    [SerializeField] private Info info;
    public string path;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        path = Application.persistentDataPath;
    }
    void Update()
    {
        Display();
    }
    void Display()
    {
        if (Directory.Exists(Application.persistentDataPath + "/Basic"))
        {
            if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
            {
                coins_text.text = Save_manager.Instance.basic.cash.ToString("n1");

                if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                    {
                        heart_amount.text = Save_manager.Instance.powerups.HEARTS.ToString("n1");
                    }
                    else
                    {
                        heart_amount.text = "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    heart_amount.text = "There was a problem during this action. Please relog";
                }
            }
            else
            {
                coins_text.text = "There was a problem during this action. Please relog";
            }
        }
        else
        {
            coins_text.text = "There was a problem during this action. Please relog";
        }
    }
    public void UI_buttons(string name)
    {
        switch (name)
        {
            case "Play":
                if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                    {
                        if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                        {
                            if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                            {
                                if (!CharacterScreen_panel.activeInHierarchy)
                                {
                                    Enable_Disable(CharacterScreen_panel, true);
                                }
                                else
                                {
                                    Enable_Disable(Alert_panel, true);
                                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                        "Character screen already been activated";
                                }
                            }
                            else
                            {
                                Enable_Disable(Alert_panel, true);
                                Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                    "There was a problem during this action. Please relog";
                            }
                        }
                        else
                        {
                            Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                "There was a problem during this action. Please relog";
                        }
                    }
                    else
                    {
                        Enable_Disable(Alert_panel, true);
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    Enable_Disable(Alert_panel, true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                        "There was a problem during this action. Please relog";
                }
                break;
            case "Settings":
                if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                    {
                        if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                        {
                            if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                            {
                                if (!Settings_panel.activeInHierarchy)
                                {
                                    for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
                                    {
                                        if (Audio_manager.Instance.ASources[i] != null)
                                        {
                                            Enable_Disable(Settings_panel, true);
                                            Enable_Disable(MainMenu_panel, false);
                                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                                        }
                                        else
                                        {
                                            Debug.LogError("Audio sources is not found");
                                        }
                                    }
                                }
                                else
                                {
                                    Enable_Disable(Settings_panel, false);
                                    Enable_Disable(MainMenu_panel, true);
                                }
                            }
                            else
                            {
                                Enable_Disable(Alert_panel, true);
                                Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                    "There was a problem during this action. Please relog";
                            }
                        }
                        else
                        {
                            Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                "There was a problem during this action. Please relog";
                        }
                    }
                    else
                    {
                        Enable_Disable(Alert_panel, true);
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    Enable_Disable(Alert_panel, true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                        "There was a problem during this action. Please relog";
                }
                break;
            case "Settings quit":
                if (Settings_panel.activeInHierarchy)
                {
                    Enable_Disable(Settings_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                else
                {
                    Enable_Disable(Settings_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                break;
            case "Shop":
                if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                    {
                        if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                        {
                            if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                            {
                                if (!Settings_panel.activeInHierarchy)
                                {
                                    for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
                                    {
                                        if (Audio_manager.Instance.ASources[i] != null)
                                        {
                                            Enable_Disable(Shop_panel, true);
                                            Enable_Disable(MainMenu_panel, false);
                                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                                        }
                                        else
                                        {
                                            Debug.LogError("Audio sources is not found");
                                        }
                                    }
                                }
                                else
                                {
                                    Enable_Disable(Shop_panel, false);
                                    Enable_Disable(MainMenu_panel, true);
                                }
                            }
                            else
                            {
                                Enable_Disable(Alert_panel, true);
                                Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                    "There was a problem during this action. Please relog";
                            }
                        }
                        else
                        {
                            Enable_Disable(Alert_panel, true);
                            Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                "There was a problem during this action. Please relog";
                        }
                    }
                    else
                    {
                        Enable_Disable(Alert_panel, true);
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this action. Please relog";
                    }
                }
                else
                {
                    Enable_Disable(Alert_panel, true);
                    Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                        "There was a problem during this action. Please relog";
                }
                break;
            case "Shop quit":
                if (Settings_panel.activeInHierarchy)
                {
                    Enable_Disable(Shop_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                else
                {
                    Enable_Disable(Shop_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                break;
            case "Credit":
                if (!Credit_panel.activeInHierarchy)
                {
                    for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
                    {
                        if (Audio_manager.Instance.ASources[i] != null)
                        {
                            Enable_Disable(Credit_panel, true);
                            Enable_Disable(MainMenu_panel, false);
                            Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                        }
                        else
                        {
                            Debug.LogError("Audio sources is not found");
                        }
                    }
                }
                else
                {
                    Enable_Disable(Credit_panel, true);
                    Enable_Disable(MainMenu_panel, false);
                }
                break;
            case "Credit quit":
                if (Credit_panel.activeInHierarchy)
                {
                    Enable_Disable(Credit_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                else
                {
                    Enable_Disable(Credit_panel, false);
                    Enable_Disable(MainMenu_panel, true);
                }
                break;
            case "Info":
                for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
                {
                    if (Audio_manager.Instance.ASources[i] != null)
                    {
                        Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                        Enable_Disable(Alert_panel, true);
                       Enable_Disable(Alert_panel.transform.Find("Info panel").gameObject, true);
                        Alert_panel.transform.Find("Info panel").Find("Text (TMP)").GetComponent<TMP_Text>()
                            .text = info.helpDescription;
                        Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
    .text = "";
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject, false);
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("No").gameObject, false);
                    }
                    else
                    {
                        Debug.LogError("Audio sources is not found");
                    }
                }
                break;
            case "Quit":
                for (int i = 0; i < Audio_manager.Instance.ASources.Length; i++)
                {
                    if (Audio_manager.Instance.ASources[i] != null)
                    {
                        Audio_manager.Instance.playSound("Enter", Save_manager.Instance.ui_sound_effects.sound_vfx);
                    Enable_Disable(Alert_panel, true);
                        UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
            .text = "Are you sure you want to quit?";
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject, true);
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("No").gameObject, true);
                    }
                    else
                    {
                        Debug.LogError("Audio sources is not found");
                    }
                }
                break;
        }
    }
    public void Enable_Disable(GameObject go, bool boolean)
    {
        go.SetActive(boolean);
    }
}
