using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class Character_selection : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPlayer;
    [SerializeField] private GameObject characterContainer;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private bool ignoreCharacterSelection;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Enemy_1 enemy1;
    [SerializeField] private Bomb bomb;
    void Awake()
    {
        if (!ignoreCharacterSelection)
        {
            if (Directory.Exists(Application.persistentDataPath + "/Basic"))
            {
                if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
                {
                    if (Save_manager.Instance)
                    {
                        if (Save_manager.Instance.basic.character.Equals("Cube"))
                        {
                            GameObject playingCharacter = Instantiate(spawnPlayer[0]);
                            playingCharacter.transform.SetParent(characterContainer.transform);
                            gameUI.player = GameObject.Find("Cube(Clone)").GetComponent<Player>();
                            enemy.player = GameObject.Find("Cube(Clone)").GetComponent<Player>();
                            enemy1.player = GameObject.Find("Cube(Clone)").GetComponent<Player>();
                            bomb.player = GameObject.Find("Cube(Clone)").GetComponent<Player>();
                        }
                        else if (Save_manager.Instance.basic.character.Equals("Sphere"))
                        {
                            GameObject playingCharacter = Instantiate(spawnPlayer[1]);
                            playingCharacter.transform.SetParent(characterContainer.transform);
                            gameUI.player = GameObject.Find("Sphere(Clone)").GetComponent<Player>();
                            enemy.player = GameObject.Find("Sphere(Clone)").GetComponent<Player>();
                            enemy1.player = GameObject.Find("Sphere(Clone)").GetComponent<Player>();
                            bomb.player = GameObject.Find("Sphere(Clone)").GetComponent<Player>();
                        }
                        else if (Save_manager.Instance.basic.character.Equals(null))
                        {
                            SceneManager.LoadScene(1);
                        }
                    }
                    else
                    {
                        Debug.LogError("There was a problem during this action");
                    }
                }
                else
                {
                    Debug.LogError("There was a problem during this action");
                }
            }
            else
            {
                Debug.LogError("There was a problem during this action");
            }
        }
        else
        {
            GameObject spawnedPlayer = Instantiate(spawnPlayer[Random.Range(0, spawnPlayer.Length)]);
            spawnedPlayer.transform.SetParent(characterContainer.transform);
            gameUI.player = GameObject.Find(spawnedPlayer.name).GetComponent<Player>();
            enemy.player = GameObject.Find(spawnedPlayer.name).GetComponent<Player>();
            enemy1.player = GameObject.Find(spawnedPlayer.name).GetComponent<Player>();
            bomb.player = GameObject.Find(spawnedPlayer.name).GetComponent<Player>();
        }
    }
}
