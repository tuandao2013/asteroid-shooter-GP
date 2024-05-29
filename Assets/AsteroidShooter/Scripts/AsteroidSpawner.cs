using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Size of the spawner")]
    public Vector3 spawnerSize;

    [Header("Rate of spawn per second")]
    public float spawnRate = 1.0f;  // Default

    [Header("Model to spawn")]
    [SerializeField] private GameObject asteroidModel;

    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            SpawnAsteroid();
            spawnTimer = 0;
        }
    }

    private void SpawnAsteroid()
    {
        // Get a random position in the spawner box
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
                                                             UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                             UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));
        // Get a random rotation for the asteroid

        // Spawn in the asteroid to the scene
        GameObject asteroid = Instantiate(asteroidModel, spawnPoint, transform.rotation);

        asteroid.transform.SetParent(this.transform);
    }
}
