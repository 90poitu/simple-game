using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    /* SpawnManager
     * Spawns gameobjects - Timer(5s) - Not completed
     * Enemy position is on the spawn point - refer transform and set the position to 
     * be at the right spawn point - Complete
     */
    [SerializeField] public GameObject[] SpawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject EnemyContainer;
    [SerializeField] private float defaultTimer;
    [SerializeField] private bool isStop;
    void Update()
    {
        if (!isStop)
        {
            if (defaultTimer <= 0)
            {
                EnemySpawn();
                defaultTimer = 2;
            }
            else
            {
                defaultTimer -= Time.deltaTime;
            }
        }
    }
    
    void EnemySpawn()
    {
        if (!isStop)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Vector3 spawnPoints = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;
            Quaternion defaultRotation = Quaternion.identity;

            GameObject enemy = Instantiate(enemyPrefab, spawnPoints, defaultRotation);

            enemy.transform.SetParent(EnemyContainer.transform);

            for (int i = 0; i < EnemyContainer.transform.childCount; i++)
            {
                if (EnemyContainer.transform.GetChild(i) != null)
                {
                    enemy.name = "Enemy " + i;

                    if (EnemyContainer.transform.childCount >= 5)
                    {
                        Destroy(EnemyContainer.transform.GetChild(i).gameObject);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Enemy spawner has stopped");
        }
    }
}
