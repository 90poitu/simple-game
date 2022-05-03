using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleShot : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] private float minSpeed;
    [SerializeField] [Range(0, 10)] private float maxSpeed;

    void Update()
    {
        transform.Translate(Vector3.up * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
    }
}
