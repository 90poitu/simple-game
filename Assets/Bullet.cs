using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    [SerializeField][Range(0, 5)] private int minSpeed;   
    [SerializeField][Range(0, 10)] private int maxSpeed;

    void Update()
    {
        transform.Translate(Vector3.up * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
    }
}
