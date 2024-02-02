using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform player;  // Reference to the player GameObject

    void Update()
    {
        if (player != null)
        {
            // Get the current position of the GameObject
            Vector3 currentPosition = transform.position;

            // Set the new position to only follow the player on the Y-axis
            currentPosition.y = player.position.y;

            // Update the GameObject's position
            transform.position = currentPosition;
        }
        else
        {
            Debug.LogWarning("Player reference is not set. Please assign the player GameObject in the inspector.");
        }
    }
}