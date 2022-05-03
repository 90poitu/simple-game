using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{
    public Player player;
    public game_AudioManager game_Audio;
    [SerializeField] [Range(0, 5)] private int minSpeed;
    [SerializeField] [Range(0, 5)] private int maxSpeed;
    [SerializeField] private Slider healthBarSlider;

    void OnEnable()
    {
        game_Audio.playAudio("Bomb_dropping"); 
    }
    void Awake()
    {
        game_Audio = GameObject.Find("audioManager").GetComponent<game_AudioManager>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            player.PlayerDamage(2);
            player.damageTaken += 2;
            game_Audio.stopAudio("Bomb_dropping");
            Destroy(gameObject);
        }
        else if (other.GetComponent<Bullet>() != null)
        {
            player.kills += 1;
            game_Audio.stopAudio("Bomb_dropping");
            Destroy(gameObject);
        }
        else if (other.GetComponent<tripleShot>() != null)
        {
            player.kills += 1;
            game_Audio.stopAudio("Bomb_dropping");
            Destroy(gameObject);
        }
    }
}
