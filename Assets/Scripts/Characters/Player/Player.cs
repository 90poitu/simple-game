using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)] public int speed;
    [Range(0, 30)] public int health;
    [Range(0, 30)] public int shield;
    public int kills;
    public int damageTaken;
    public int bulletFire;
    [SerializeField] [Range(0, 30)] private int damageAmount;
    public float speedTimer;
    public float tripleShotTimer;
    public float shootingTimer;
    [SerializeField] private Rigidbody2D Rigidbody2D;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject UIlosescreen;
    [SerializeField] private GameObject tripleShotPrefab;
    public GameObject game_Audio;
    private void OnEnable()
    {
        game_Audio.GetComponent<game_AudioManager>().playAudio("Single_shot");
    }
    void Update()
    {
        PlayerMovement();
        speedGear();
        PlayerShooting();
        tripleShotGear();
    }
    void tripleShotGear()
    {
        if (tripleShotTimer > 0)
        {
            tripleShotTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (tripleShotTimer <= 0)
            {
                GameObject TripleShot = Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
                game_Audio.GetComponent<game_AudioManager>().playAudio("Triple_shot");
                TripleShot.transform.SetParent(GameObject.Find("bulletPrefab_Container").transform);
                bulletFire += 3;
                tripleShotTimer += 1;
            }
        }
    }
    void speedGear()
    {
        if (speedTimer > 0)
        {
            speedTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (speedTimer <= 0)
            {
                speed += 2;
                speedTimer += 1.7f;
            }
        }
    }
    void PlayerMovement()
    {
        float horizonalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizonalInput * speed * Time.smoothDeltaTime);

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
    }
    public void PlayerDamage(int damageAmount)
    {
        if (shield > 0)
        {
            int TotalShieldDamage = shield -= damageAmount;
            Debug.Log(TotalShieldDamage);
        }
        else
        {
            health -= damageAmount;
        }
        damageTaken += damageAmount;
        if (health <= 0)
        {
            Time.timeScale = 0;
            UIlosescreen = GameObject.Find("Game UI").transform.Find("Lose screen").gameObject;
            UIlosescreen.SetActive(true);
        }
    }
    void PlayerShooting()
    {
        if (shootingTimer > 0)
        {
            shootingTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && shootingTimer <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            game_Audio.GetComponent<game_AudioManager>().playAudio("Single_shot");
            bullet.transform.SetParent(GameObject.Find("bulletPrefab_Container").transform);
            bulletFire++;
            shootingTimer += .5f;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            PlayerDamage(2);
            Destroy(other.GetComponent<Enemy>().gameObject);
        }
        else if (other.GetComponent<Enemy_1>() != null)
        {
            PlayerDamage(4);
            Destroy(other.GetComponent<Enemy_1>().gameObject);
        }
    }
}
