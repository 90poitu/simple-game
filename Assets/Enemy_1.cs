using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy_1 : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] private float minSpeed;
    [SerializeField] [Range(0, 10)] private float maxSpeed;
    [SerializeField] [Range(0, 5)] private int health;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private TMP_Text healthText;
    public Player player;

    void Update()
    {
        transform.Translate(Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        healthBarSlider.value = health;
        healthText.text = health + "/" + healthBarSlider.maxValue;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            if (health > 0)
            {
                health--;
            }
            else
            {
                Destroy(gameObject);
                player.kills += 1;
            }
        }
        else if (other.GetComponent<tripleShot>() != null)
        {
            if (health > 0)
            {
                health -= 3;
            }
            else
            {
                Destroy(gameObject);
                player.kills += 1;
            }
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
