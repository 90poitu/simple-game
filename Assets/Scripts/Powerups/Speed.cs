using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int speed;
    [SerializeField] [Range(0, 10)] private int SpeedPowerupAmount;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(speedPickup(SpeedPowerupAmount));
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator speedPickup(int amount)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.speed += amount;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5f);
        player.speed -= amount;
        Destroy(gameObject);
    }
}
