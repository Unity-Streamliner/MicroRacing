using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGain = 0.1f;
    void Update()
    {
        IncreaseSpeed();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void IncreaseSpeed()
    {
        speed += speedGain * Time.deltaTime;
    }
}
