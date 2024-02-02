using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Spawnpoints : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private int numberOfObjectsToSpawn = 10;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private GameObject playerRadius;

    private void Start()
    {
        if (spawnPoints.Count == 0 || prefabs.Count == 0)
        {
            Debug.LogError("Spawn points or prefabs lists are empty. Please assign them in the inspector.");
            return;
        }

        StartCoroutine(SpawnObjectsOverTime());
    }

    IEnumerator SpawnObjectsOverTime()
    {
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Check if there are available spawn points
            if (availableSpawnPoints.Count == 0)
            {
                Debug.LogWarning("Not enough available spawn points. Stopping spawning.");
                yield break;
            }

            // Get a random spawn point and prefab
            int randomSpawnIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform randomSpawnPoint = availableSpawnPoints[randomSpawnIndex];
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Count)];

            // Instantiate the prefab at the random spawn point
            //if(playerRadius)
            //Instantiate(randomPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

            // Remove the used spawn point
            availableSpawnPoints.RemoveAt(randomSpawnIndex);

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("SpawnPoints"))
        {
            Debug.Log("Prefab");
        }
    }
}