using UnityEngine;
using UnityEngine.UI;

public class Gravity_UI_New : MonoBehaviour
{
    [SerializeField] private float maxGravity = 100f; // Assuming this is the maximum gravity value
    [SerializeField] private float playerGravity; // Current gravity value
    [SerializeField] private float gravityDecrementRate; // Rate at which gravity decreases per frame
    [SerializeField] private Image gravityUIImage; // Reference to your UI Image

    private void Start()
    {
        playerGravity = maxGravity; // Set the initial gravity to the maximum value
        UpdateUI();
    }

    private void Update()
    {
        // Decrease gravity every frame
        playerGravity -= gravityDecrementRate * Time.deltaTime;
        playerGravity = Mathf.Clamp(playerGravity, 0f, maxGravity); // Ensure gravity doesn't go below 0

        UpdateUI();
    }

    public void PickupItem(float pickupAmount)
    {
        playerGravity += pickupAmount; // Add the pickupAmount to the player's gravity value
        playerGravity = Mathf.Clamp(playerGravity, 0f, maxGravity); // Ensure gravity doesn't exceed the maximum value
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update the UI Image fill amount based on the normalized gravity value
        if (gravityUIImage != null)
        {
            float normalizedGravity = playerGravity / maxGravity;
            gravityUIImage.fillAmount = normalizedGravity;
        }
    }
}
