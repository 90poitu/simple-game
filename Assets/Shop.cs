using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Shop : MonoBehaviour
{
    [SerializeField] public TMP_Text coinText;
    [SerializeField] public GameObject shop_alert;
    [SerializeField] public TMP_Text[] texts;
    [SerializeField] public TMP_Text[] costtexts;
    [SerializeField] [TextArea] public string[] TITLE;
    [SerializeField] public float[] COST;
    void Update()
    {
        itemDisplay();
        GetCashValue(coinText);
    }
    void itemDisplay()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = TITLE[i];
            costtexts[i].text = COST[i].ToString();
        }
    }
    public void itemsClick(string name)
    {
        switch (name)
        {
            case "HEART":
                if (!shop_alert.activeInHierarchy)
                {
                    UI_manager.Instance.Enable_Disable(shop_alert, true);
                }
                break;
        }
    }
    public void itemsAmountClick(float amount)
    {
        switch (amount)
        {
            case 1:
                if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                    {
                        if (Save_manager.Instance.basic.cash >= 25)
                        {
                            Save_manager.Instance.basic.cash -= 25;
                            Save_manager.Instance.powerups.HEARTS += 1;
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                                .text = "Successfully purchased." + " Item: Heart";
                            Debug.Log("Successfully purchased." + " Item: Heart");
                        }
                        else
                        {
                            Debug.LogError("You do not have enough money!");
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                                .text = "Fail purchased due to lack of funds";
                        }
                    }
                    else
                    {
                        Debug.LogError("There was a problem buying an item");
                    }
                }
                else
                {
                    Debug.LogError("There was a problem buying an item");
                }
                break;
            case 3:
                if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                    {
                        if (Save_manager.Instance.basic.cash >= 45)
                        {
                            Save_manager.Instance.basic.cash -= 45;
                            Save_manager.Instance.powerups.HEARTS += 3;
                            Debug.Log("Successfully purchased." + " Item: Heart");
                        }
                        else
                        {
                            Debug.LogError("You do not have enough money!");
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                                .text = "Fail purchased due to lack of funds";
                        }
                    }
                    else
                    {
                        Debug.LogError("There was a problem buying an item");
                    }
                }
                else
                {
                    Debug.LogError("There was a problem buying an item");
                }
                break;
            case 5:
                if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
                    {
                        if (Save_manager.Instance.basic.cash >= 65)
                        {
                            Save_manager.Instance.basic.cash -= 65;
                            Save_manager.Instance.powerups.HEARTS += 5;
                            Debug.Log("Successfully purchased." + " Item: Heart");
                        }
                        else
                        {
                            Debug.LogError("You do not have enough money!");
                            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
                            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>()
                                .text = "Fail purchased due to lack of funds";
                        }
                    }
                    else
                    {
                        Debug.LogError("There was a problem buying an item");
                    }
                }
                else
                {
                    Debug.LogError("There was a problem buying an item");
                }
                break;
        }
    }
    void GetCashValue(TMP_Text coinText)
    {
        if (Directory.Exists(Application.persistentDataPath + "/Powerups"))
        {
            if (File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
            {
                if (coinText != null)
                {
                    coinText.text = Save_manager.Instance.basic.cash.ToString("n1");
                }
                else
                {
                    coinText.text = "There was a problem during this action";
                }
            }
            else
            {
                coinText.text = "There was a problem during this action";
            }
        }
        else
        {
            coinText.text = "There was a problem during this action";
        }
    }
    public void quitShopPopup()
    {
        UI_manager.Instance.Enable_Disable(shop_alert, false);
    }
}
