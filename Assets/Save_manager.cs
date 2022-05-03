using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using TMPro;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class Save_manager : MonoBehaviour
{
    [System.Serializable]
    public class UI_sound_effects {
        public float sound_vfx;
    }
    [System.Serializable]
    public class Basic
    {
        public int cash;
        public string character;
        public float bestTime;
        public float gameStartTime;
    }
    [System.Serializable]
    public class Powerups
    {
        public int HEARTS;
    }
    public UI_sound_effects ui_sound_effects;
    public Basic basic;
    public Powerups powerups;
    [TextArea] private string GameFeedbackForm = "https://docs.google.com/forms/d/1-M7Ppy7jwdYEQQVsCUG0Uk6qm0ozvgg6_XUZtMqkV9U";
    public static Save_manager Instance;
    [TextArea] public string Error_message = "Creating save files. Please relog.";
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects") && Directory.Exists(Application.persistentDataPath + "/Basic") && Directory.Exists(Application.persistentDataPath + "/Powerups"))
        {
            if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat") && File.Exists(Application.persistentDataPath + "/Basic/Basic.dat") && File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat"))
            {
                UI_sound_effect_load(); Basic_load(); Powerups_load();
            }
            else
            {
                UI_sound_effect_save(); Basic_save(); Powerups_save();
            }
        }
        else
        {
            createDataFiles(Application.persistentDataPath + "/UIsoundeffects");
            createDataFiles(Application.persistentDataPath + "/Basic");
            createDataFiles(Application.persistentDataPath + "/Powerups");
        }
        relog();
    }
    void createDataFiles(string folder)
    {
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }
    public void Powerups_save()
    {
        string path = Application.persistentDataPath + "/Powerups/Powerups.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, powerups);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue serializing this data" + e.Message);
        }
        finally
        {
            stream.Close();
        }
    }
    public void Basic_save()
    {
        string path = Application.persistentDataPath + "/Basic/Basic.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, basic);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue serializing this data" + e.Message);
        }
        finally
        {
            stream.Close();
        }
    }
    public void UI_sound_effect_save()
    {
        string path = Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, ui_sound_effects);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue serializing this data" + e.Message);
        }
        finally
        {
            stream.Close();
        }
    }

    public void UI_sound_effect_load()
    {
        string path = Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                UI_sound_effects data = (UI_sound_effects)formatter.Deserialize(stream);
                ui_sound_effects = data;
            }
            catch (SerializationException e)
            {
                Debug.LogError("There was an issue serializing this data" + e.Message);
            }
            finally
            {
                stream.Close();
            }
        }
    }
    public void Powerups_load()
    {
        string path = Application.persistentDataPath + "/Powerups/Powerups.dat";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Powerups data = (Powerups)formatter.Deserialize(stream);
                powerups = data;
            }
            catch (SerializationException e)
            {
                Debug.LogError("There was an issue serializing this data" + e.Message);
            }
            finally
            {
                stream.Close();
            }
        }
    }
    public void Basic_load()
    {
        string path = Application.persistentDataPath + "/Basic/Basic.dat";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Basic data = (Basic)formatter.Deserialize(stream);
                basic = data;
            }
            catch (SerializationException e)
            {
                Debug.LogError("There was an issue serializing this data" + e.Message);
            }
            finally
            {
                stream.Close();
            }
        }
    }
    void OnApplicationQuit()
    {
        if (Directory.Exists(Application.persistentDataPath + "/UIsoundeffects") && Directory.Exists(Application.persistentDataPath + "/Basic"))
        {
            if (File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat") && File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
            {
                UI_sound_effect_save(); Basic_save(); Powerups_save();
                basic.character = "";
                Application.OpenURL(GameFeedbackForm);
                Debug.Log("Saving datafile");
            }
            else
            {
                Debug.LogError(Error_message);
            }
        }
        else
        {
            Debug.LogError(Error_message);
        }
    }
    void relog()
    {
        if (!File.Exists(Application.persistentDataPath + "/UIsoundeffects/UIsoundeffects.dat") && !File.Exists(Application.persistentDataPath + "/Basic/Basic.dat") && !File.Exists(Application.persistentDataPath + "/Powerups/Powerups.dat")) {
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel, true);
            UI_manager.Instance.Alert_panel.transform.Find("Body").GetComponent<TMP_Text>().text
                = Error_message;
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.Alert_panel.transform.Find("Quit").gameObject, false);
            UI_manager.Instance.Enable_Disable(UI_manager.Instance.MainMenu_panel, false);
        }
    }
}
