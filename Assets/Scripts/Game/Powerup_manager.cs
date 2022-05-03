using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_manager : MonoBehaviour
{
    [SerializeField] private GameObject PowerupContainer;
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private float DefaultTimer;
    [SerializeField] private Spawn_manager SpawnManager;
    [SerializeField] private bool isStop;

    void Update()
    {
        if (!isStop)
        {
            if (DefaultTimer <= 0)
            {
                SpawnPowerup();
                DefaultTimer = 3;
            }
            else
            {
                DefaultTimer -= Time.deltaTime;
            }
        }
    }

    void SpawnPowerup()
    {
        if (!isStop)
        {
            if (SpawnManager != null)
            {
                GameObject powerupPrefab = powerups[Random.Range(0, powerups.Length)];
                Vector3 spawnPoints = SpawnManager.SpawnPoints[Random.Range(0, SpawnManager.SpawnPoints.Length)].transform.position;
                Quaternion defaultRotation = Quaternion.identity;
                GameObject powerup = Instantiate(powerupPrefab, spawnPoints, defaultRotation);

                powerup.transform.SetParent(PowerupContainer.transform);

                for (int i = 0; i < PowerupContainer.transform.childCount; i++)
                {
                    if (PowerupContainer.transform.GetChild(i) != null)
                    {
                        powerup.name = "Powerup " + i;

                        if (PowerupContainer.transform.childCount >= 5)
                        {
                            Destroy(PowerupContainer.transform.GetChild(i).gameObject);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Powerup spawner has stopped");
        }
    }
}
