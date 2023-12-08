using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawnPrefab;
    public Transform[] spawnPoints;
    public float despawnTime = 5f; // Time before despawning in seconds
    public float respawnTime = 2f; // Time before respawning in seconds

    private bool isObjectSpawned = false;

    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            if (!isObjectSpawned)
            {
                SpawnObjectRandomly();
                isObjectSpawned = true;

                // Wait for the despawn time
                yield return new WaitForSeconds(despawnTime);

                DespawnObject();
                isObjectSpawned = false;

                // Wait for the respawn time
                yield return new WaitForSeconds(respawnTime);
            }
            else
            {
                // If an object is already spawned, wait for a short time before checking again
                yield return new WaitForSeconds(1f);
            }
        }
    }

    void SpawnObjectRandomly()
    {
        if (objectToSpawnPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Object to spawn prefab or spawn points are not set!");
            return;
        }

        // Choose a random spawn point index
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

        // Get the chosen spawn point
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate the prefab at the chosen spawn point
        objectToSpawn = Instantiate(objectToSpawnPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void DespawnObject()
    {
        // Check if there is an object spawned
        if (objectToSpawn != null)
        {
            // Destroy the spawned object
            Destroy(objectToSpawn);
        }
    }
}
