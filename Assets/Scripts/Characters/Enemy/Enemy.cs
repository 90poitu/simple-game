using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public Player player;
    [SerializeField] [Range(0, 10)] private int minSpeed;
    [SerializeField] [Range(0, 10)] private int maxSpeed;
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        transform.Translate(Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
            player.kills += 1;
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
