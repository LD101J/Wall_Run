using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float detectionRadius = 10f; // Radius to detect the player
    public float spawnAreaSize = 20f; // Size of the square spawn area
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to be spawned

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
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

    void OnDrawGizmos()
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