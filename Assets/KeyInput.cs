using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyInput : MonoBehaviour
{
    private float seconds;
    public KeyCode quitKey;
    public KeyCode ConfirmQuitKey;
    public KeyCode ShopPanelKey;
    public KeyCode CreditPanelKey;
    public KeyCode SettingPanelKey;
    public KeyCode PlayKey;
    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            if (UI_manager.Instance.Settings_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, false);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, true);
            }
            else if (UI_manager.Instance.Credit_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Credit_panel, false);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, true);
            }
            else if (UI_manager.Instance.Shop_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Shop_panel, false);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, true);
            }
            else if (UI_manager.Instance.Alert_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject, false);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("No").gameObject, false);
                if (UI_manager.Instance.Alert_panel.transform.Find("Info panel").gameObject.activeInHierarchy)
                {
                    UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Info panel").gameObject, false);
                }
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, false);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, true);
            }
            else if (!UI_manager.Instance.Settings_panel.activeInHierarchy
                || !UI_manager.Instance.Credit_panel.activeInHierarchy ||
                !UI_manager.Instance.Shop_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject, true);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("No").gameObject, true);
                 UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                    .text = "Are you sure you want to quit?";
            }
        }
        if (Input.GetKey(ConfirmQuitKey))
        {
            if (UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject.activeInHierarchy
                && UI_manager.Instance.Alert_panel.transform.Find("No").gameObject)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                    .text = "Saving files. Quitting...";
                StartCoroutine(Quit());
            }
        }
        if (Input.GetKeyDown(CreditPanelKey))
        {
            if (!UI_manager.Instance.Credit_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Credit_panel, true);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, false);
            }
        }
        if (Input.GetKeyDown(SettingPanelKey))
        {
            if (!UI_manager.Instance.Settings_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Settings_panel, true);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, false);
            }
        }
        if (Input.GetKeyDown(PlayKey))
        {
            if (UI_manager.Instance.MainMenu_panel.activeInHierarchy)
            {
                SceneManager.LoadScene(1);
            }
        }
        if (Input.GetKeyDown(ShopPanelKey))
        {
            if (!UI_manager.Instance.Shop_panel.activeInHierarchy)
            {
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.Shop_panel, true);
                UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, false);
            }
        }
    }

    IEnumerator Quit()
    {
        UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
    .text = "Saving files. Quitting...";
        yield return new WaitForSeconds(seconds);
        Application.Quit();
        Debug.Log("You quit");
    }

   public void QuitApplication()
    {
        StartCoroutine(Quit());
        //Application.Quit(); Debug.Log("You quit");
    }

    public void Resume()
    {
        if (UI_manager.Instance.Alert_panel.activeInHierarchy)
        {
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Yes").gameObject, false);
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("No").gameObject, false);
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Info panel").gameObject, false);
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, false);
        }
    }
}
