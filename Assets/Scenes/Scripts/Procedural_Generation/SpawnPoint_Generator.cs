using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] wallPrefabs; // Array of wall prefabs to choose from
    [SerializeField] private Transform generation_Point;
    [SerializeField] private float distance_Between;

    private void Update()
    {
        if (transform.position.x < generation_Point.position.x)
        {
            SpawnWall();
        }
    }

    private void SpawnWall()
    {
        float randomY = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(transform.position.x + distance_Between, randomY, transform.position.z);

        int randomIndex = Random.Range(0, wallPrefabs.Length);
        GameObject wallPrefab = wallPrefabs[randomIndex];

        Instantiate(wallPrefab, spawnPosition, transform.rotation);

        transform.position = new Vector3(spawnPosition.x + wallPrefab.GetComponent<BoxCollider2D>().size.x, randomY, transform.position.z);
    }
}