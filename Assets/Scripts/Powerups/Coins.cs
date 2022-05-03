using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int speed;
    [SerializeField] [Range(0, 200)] private int coins;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            CoinsPickup(1, coins);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    void CoinsPickup(int min, int max)
    {
        if (Directory.Exists(Application.persistentDataPath + "/Basic"))
        {
            if (File.Exists(Application.persistentDataPath + "/Basic/Basic.dat"))
            {
                if (Save_manager.Instance)
                {
                    Save_manager.Instance.basic.cash += Random.Range(min, max);
                    Save_manager.Instance.Basic_save();
                }
                else
                {
                    Debug.LogError("Save file didn't get detected");
                }
            }
            else
            {
                Debug.LogError("There was a problem while collecting coins");
            }
        }
        else
        {
            Debug.LogError("There was a problem while collecting coins");
        }
    }
}
