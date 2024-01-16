using UnityEngine;
using System.Collections;
public class MigwiandRita : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player GameObject
    [SerializeField] private float detectionRadius = 10f; // Radius to detect the player
    [SerializeField] private float spawnAreaSize = 20f; // Size of the square spawn area
    [SerializeField] private float spawnTimer = 1f; // Time interval between spawns
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs to be spawned

    private void Start()
    {
        // Start the spawn coroutine
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        // Infinite loop for continuous spawning
        while (true)
        {
            // Check if the player is within the detection radius
            if (Vector2.Distance(transform.position, player.position) < detectionRadius)
            {
                SpawnEnemy();
            }

            // Wait for the specified spawn timer duration before spawning again
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void SpawnEnemy()
    {
        // Randomly select an enemy prefab from the array
        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Randomly generate a position within the spawn area
        Vector2 spawnPosition = new Vector2(
            transform.position.x + Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2),
            transform.position.y + Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2)
        );
       
        // Instantiate the selected enemy prefab at the generated position
        Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        // Draw detection radius Gizmo
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Draw spawn area Gizmo
        Gizmos.color = Color.green;
        Vector2 center = transform.position;
        Vector2 size = new Vector2(spawnAreaSize, spawnAreaSize);
        Gizmos.DrawWireCube(center, size);
    }
}