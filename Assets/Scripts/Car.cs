using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds = new Vector2(8.5f, 4.5f);

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateSpeed();
    }
    private void Update()
    { // if car is out of bounds
        if (transform.position.y < -screenBounds.y || transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
        {
            int rndY = Convert.ToInt32(UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
            int rndX = UnityEngine.Random.Range(-1, 1);
            if (rndX == -1)
            {
                speed = -Math.Abs(speed);
                speed -= 0.5f;
                if (speed < -maxSpeed) { speed = -maxSpeed; }
            }
            else
            {
                rndX = 1;
                speed = Math.Abs(speed);
                speed += 0.5f;
                if (speed > maxSpeed) { speed = maxSpeed; }
            }
            UpdateSpeed();
            transform.position = new Vector3(-screenBounds.x * rndX, rndY + 0.5f);
        }
    }

    void UpdateSpeed()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    public void Move(int addY)
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
        {
            car.transform.position += new Vector3(0, addY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Car"))
        {
            collision.rigidbody.AddForce(new Vector3(-2 * collision.rigidbody.velocity.x, 0), ForceMode2D.Force);
        }
    }
}
