using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPageInput : MonoBehaviour
{
    [SerializeField] private KeyCode PlayKey;
    [SerializeField] private KeyCode QuitKey;
    [TextArea] private string GameFeedbackForm = "https://docs.google.com/forms/d/1-M7Ppy7jwdYEQQVsCUG0Uk6qm0ozvgg6_XUZtMqkV9U";
    void Update()
    {
        if (Input.GetKeyDown(PlayKey))
        {
            loadScene(1);
        }
        if (Input.GetKeyDown(QuitKey))
        {
            Quit();
        }
    }

    public void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    void OnApplicationQuit()
    {
        Application.OpenURL(GameFeedbackForm);
    }
}
