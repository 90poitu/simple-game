using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int speed;
    [SerializeField] [Range(0, 10)] private int shieldAmount;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shieldPickup(shieldAmount);
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }

    void shieldPickup(int amount)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.shield += amount;
        Destroy(gameObject);
    }
}
