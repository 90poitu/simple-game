using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    public Player player;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text speedCooldownText;
    [SerializeField] private TMP_Text tripleShotCooldownText;
    [SerializeField] private TMP_Text totalCoinText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text timerTextlosescreen;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text damageTakenText;
    [SerializeField] private TMP_Text bulletFireText;
    [SerializeField] private TMP_Text normalFireText;
    public float startTime;
    void Start()
    {
        startSurvivalTime();
    }
    void Update()
    {
        GetHealthSliderValue(healthSlider, healthText);
        GetShieldSliderValue(shieldSlider, shieldText);
        GetSpeedValue(speedText);
        GetKillValue(killText);
        GetSpeedCooldownText(speedCooldownText);
        GetTotalCoinText(totalCoinText);
        GetSurvivalTimeText(timerText, timerTextlosescreen);
        GetKillsText(killsText);
        GetTripleShotCooldownText(tripleShotCooldownText);
        GetDamageTakenText(damageTakenText);
        GetBulletText(bulletFireText);
        GetNormalFireCooldownText(normalFireText);
    }

    void GetHealthSliderValue(Slider healthSlider, TMP_Text healthText)
    {
        if (player != null)
        {
            if (healthSlider != null)
            {
                healthSlider.value = player.health;

                if (healthText != null)
                {
                    healthText.text = player.health + "/" + healthSlider.maxValue;
                }
                else
                {
                    Debug.LogError("Health text is not found");
                }
            }
            else
            {
                Debug.LogError("Health slider is not found");
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetShieldSliderValue(Slider shieldSlider, TMP_Text shieldText)
    {
        if (player != null)
        {
            if (shieldSlider != null)
            {
                shieldSlider.value = player.shield;

                if (shieldText != null)
                {
                    shieldText.text = player.shield + "/" + shieldSlider.maxValue;
                }
                else
                {
                    Debug.LogError("Shield text is not found");
                }
            }
            else
            {
                Debug.LogError("Shield slider is not found");
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetSpeedValue(TMP_Text speedText)
    {
        if (player != null)
        {
            if (speedText != null)
            {
                speedText.text = player.speed.ToString();
            }
            else
            {
                Debug.LogError("Speed Text is not found");
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetKillValue(TMP_Text killText)
    {
        if (player)
        {
            if (killText)
            {
                killText.text = player.kills.ToString();
            }
            else
            {
                Debug.LogError("Kills Text is not found");
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetSpeedCooldownText(TMP_Text speedCooldownText)
    {
        if (player)
        {
            if (speedCooldownText)
            {
                if (player.speedTimer > 0)
                {
                    speedCooldownText.text = "Speed: " + player.speedTimer.ToString("n1");
                }
                else
                {
                    speedCooldownText.text = "Speed: Ready";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetTotalCoinText(TMP_Text TotalCoinText)
    {
        if (player)
        {
            if (TotalCoinText)
            {
                if (Directory.Exists(Application.persistentDataPath + "/Basic"))
                {
                    if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                    {
                        if (Save_manager.Instance)
                        {
                            TotalCoinText.text = Save_manager.Instance.basic.cash.ToString();
                        }
                        else
                        {
                            TotalCoinText.text = "Save file didn't get detected";
                        }
                    }
                    else
                    {
                        TotalCoinText.text = "Save file didn't get detected";
                    }
                }
                else
                {
                    TotalCoinText.text = "Save file didn't get detected";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetSurvivalTimeText(TMP_Text survivalText, TMP_Text timerTextlosescreen)
    {
        if (player)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;

            if (survivalText)
            {
                survivalText.text = minutes + ":" + seconds;
                if (timerTextlosescreen)
                {
                    timerTextlosescreen.text = minutes + ":" + seconds;
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
     void GetKillsText(TMP_Text killsText)
    {
        if (player)
        {
            if (killsText)
            {
                if (player.kills >= 0) 
                {
                    killsText.text = player.kills.ToString();
                }
                else
                {
                    killsText.text = "No kills";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetTripleShotCooldownText(TMP_Text tripleShotText)
    {
        if (player)
        {
            if (tripleShotText)
            {
                if (player.tripleShotTimer > 0)
                {
                    tripleShotText.text = "Triple shot: " + player.tripleShotTimer.ToString("n1");
                }
                else
                {
                    tripleShotText.text = "Triple shot: Ready";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetDamageTakenText(TMP_Text damageTakenText)
    {
        if (player)
        {
            if (damageTakenText)
            {
                if (player.damageTaken > 0)
                {
                    damageTakenText.text = player.damageTaken.ToString();
                }
                else
                {
                    damageTakenText.text = "No damage taken";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetBulletText(TMP_Text bulletFireText)
    {
        if (player)
        {
            if (bulletFireText)
            {
                if (player.bulletFire > 0)
                {
                    bulletFireText.text = player.bulletFire.ToString();
                }
                else
                {
                    bulletFireText.text = "No bullet fire";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    void GetNormalFireCooldownText(TMP_Text normalFire)
    {
        if (player)
        {
            if (normalFire)
            {
                if (player.shootingTimer > 0)
                {
                    normalFire.text = "Fire: " + player.shootingTimer.ToString("n1");
                }
                else
                {
                    normalFire.text = "Fire";
                }
            }
        }
        else
        {
            Debug.LogError("Player is not found");
        }
    }
    public void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    void startSurvivalTime()
    {
        startTime = Time.time;
        Save_manager.Instance.basic.gameStartTime = startTime;
    }
}
