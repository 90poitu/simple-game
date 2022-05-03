using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /* Health class
     * Triggers the collider
     * Heal the player - 10%,20% - Whole number
     * Speed of the powerup - 0,10 - Whole number - Complete
     */

    [SerializeField] [Range(0, 10)] private int speed;
    [SerializeField] [Range(0, 10)] private int AmountToHeal;
    [SerializeField] private Player player;
    void Awake()
    {
       //if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() != null)
       //{
       //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       //}
    }

    void Update()
    {
        //player.health += 5;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthPickup(AmountToHeal);
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    void healthPickup(int amount)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.health += amount;
        Destroy(gameObject);
    }
}
