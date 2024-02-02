using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject wall1; // Reference to your first wall GameObject
    public GameObject wall2; // Reference to your second wall GameObject
    public GameObject prefabToInstantiate; // Reference to your prefab

    void Start()
    {
        // Check if references are not null
        if (wall1 != null && wall2 != null && prefabToInstantiate != null)
        {
            // Create an empty parent GameObject
            GameObject wallsParent = new GameObject("WallsParent");

            // Make the walls children of the new parent
            wall1.transform.parent = wallsParent.transform;
            wall2.transform.parent = wallsParent.transform;

            // Instantiate the prefab
            GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, wallsParent.transform.position, Quaternion.identity);

            // Make the instantiated prefab a child of the new parent
            if (instantiatedPrefab != null)
            {
                instantiatedPrefab.transform.parent = wallsParent.transform;
            }
            else
            {
                Debug.LogError("Prefab instantiation failed.");
            }
        }
        else
        {
            Debug.LogError("Please assign all the necessary references in the inspector.");
        }
    }
}