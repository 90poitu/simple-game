using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class Character_screen : MonoBehaviour
{
    [SerializeField] private TMP_Text cubeText;
    [SerializeField] private TMP_Text sphereText;
    [SerializeField] private TMP_Text previousCharacterText;
    void Update()
    {
        GetPreviousCharacterText(previousCharacterText);
    }
    void GetPreviousCharacterText(TMP_Text previousCharacterText)
    {
        if (Save_manager.Instance)
        {
            if (Directory.Exists(Application.persistentDataPath + "/Basic"))
            {
                if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                {
                    if (previousCharacterText != null)
                    {
                        if (Save_manager.Instance.basic.character.Equals(""))
                        {
                            previousCharacterText.text = "";
                        }
                        else
                        {
                            previousCharacterText.text = "Your previous character: " + Save_manager.Instance.basic.character;
                        }
                    }
                    else
                    {
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                        UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this actions";
                    }
                }
                else
                {
                    UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                    UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                        "There was a problem during this actions";
                }
            }
            else
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                    "There was a problem during this actions";
            }
        }
        else
        {
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                "There was a problem during this actions";
        }
    }
    public void characterClick(string name)
    {
        switch (name)
        {
            case "Cube":
                if (UI_manager.Instance.CharacterScreen_panel.activeInHierarchy)
                {
                    if (Save_manager.Instance)
                    {
                        if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                        {
                            if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                            {
                                Save_manager.Instance.basic.character = cubeText.name;
                                SceneManager.LoadScene(2);
                            }
                            else
                            {
                                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                                UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                    "There was a problem during this actions";
                            }
                        }
                        else
                        {
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                "There was a problem during this actions";
                        }
                    }
                    else
                    {
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                        UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this actions";
                    }
                }
                break;
            case "Sphere":
                if (UI_manager.Instance.CharacterScreen_panel.activeInHierarchy)
                {
                    if (Save_manager.Instance)
                    {
                        if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                        {
                            if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                            {
                                Save_manager.Instance.basic.character = sphereText.name;
                                SceneManager.LoadScene(2);
                            }
                            else
                            {
                                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                                UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                    "There was a problem during this actions";
                            }
                        }
                        else
                        {
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                                "There was a problem during this actions";
                        }
                    }
                    else
                    {
                        UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                        UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text =
                            "There was a problem during this actions";
                    }
                }
                break;
        }
    }
    public void Quit()
    {
        if (UI_manager.Instance.CharacterScreen_panel)
        {
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.CharacterScreen_panel, false);
        }
    }
}
