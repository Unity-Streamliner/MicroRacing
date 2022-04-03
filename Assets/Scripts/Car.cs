using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGain = 0.1f;
    [SerializeField] private float turnSpeed = 200f;

    private int _steerValue;
    private string _tag = "Obstacle";

    void Update()
    {
        IncreaseSpeed();
        transform.Rotate(0f, _steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }

    private void IncreaseSpeed()
    {
        speed += speedGain * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
