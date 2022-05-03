using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameKeyInput : MonoBehaviour
{
    [SerializeField] private KeyCode PauseKey;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameUI gameUI;
    void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            if (!PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void gamePauseMenu(string name)
    {
        switch (name)
        {
            case "Resume":
                if (PausePanel.activeInHierarchy)
                {
                    PausePanel.SetActive(false);
                    Time.timeScale = 1;
                }
                break;
            case "Quit":
                if (PausePanel.activeInHierarchy)
                {
                    if (Save_manager.Instance)
                    {
                        Save_manager.Instance.Basic_save();
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        Debug.LogError("Save instance is not found");
                    }
                }
                break;
        }
    }
}
