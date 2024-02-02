using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float pickupAmount = 20f; // Adjust the amount based on your needs
    [SerializeField] private bool is_Picked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            Debug.Log("Pick");
            Destroy(gameObject); // Remove the pickup object

            // Uncomment the following lines if you want to interact with the player
            Gravity_UI_New gravityUI = other.GetComponent<Gravity_UI_New>();
            if (gravityUI != null)
            {
                gravityUI.PickupItem(pickupAmount);
                Debug.Log("UI Updated");
            }
            else
            {
                Debug.LogError("Gravity_UI_New component not found on the player.");
            }
        }
    }
}