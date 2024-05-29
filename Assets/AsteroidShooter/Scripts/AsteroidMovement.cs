using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Control the speed of the asteroid")]
    public float maxSpeed;
    public float minSpeed;

    [Header("Control the rotation speed of the asteroid")]
    public float rotationSpeedMax;
    public float rotationSpeedMin;

    private float rotationalSpeed;
    private float xAngle, yAngle, zAngle;

    public Vector3 movementDirection;

    private float asteroidSpeed;

    // Get called before the first frame
    void Start()
    {
        // Get a random speed
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        // Get a random rotation
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);

        // Get a random rotational speed
        
        rotationalSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    // Get called once per frame
    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * asteroidSpeed, Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed);
    }
}
