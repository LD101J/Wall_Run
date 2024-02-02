using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this line for SceneManager

public class Gravity_UI_New : MonoBehaviour
{
    [SerializeField] private float maxGravity = 100f;
    [SerializeField] private float playerGravity;
    [SerializeField] private float gravityDecrementRate;
    [SerializeField] private Image gravityUIImage;
    [SerializeField] private float spike;
    [SerializeField] private float Health_Pickup;

    private void Start()
    {
        playerGravity = maxGravity;
        UpdateUI();
    }

    private void Update()
    {
        playerGravity -= gravityDecrementRate * Time.deltaTime;
        playerGravity = Mathf.Clamp(playerGravity, 0f, maxGravity);
        UpdateUI();
    }

    public void PickupItem(float pickupAmount)
    {
        playerGravity += pickupAmount;
        playerGravity = Mathf.Clamp(playerGravity, 0f, maxGravity);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (gravityUIImage != null)
        {
            float normalizedGravity = playerGravity / maxGravity;
            gravityUIImage.fillAmount = normalizedGravity;
        }
        if (playerGravity == 0f)
        {
            RestartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            playerGravity -= spike;
            UpdateUI(); // Call UpdateUI here to update the UI when gravity changes due to spike

            if (playerGravity <= 0f)
            {
                RestartGame();
            }
        }
        if (other.CompareTag("Health_Pickup"))
        {
            playerGravity += Health_Pickup;
            Destroy(other.gameObject);
        }
    }

    private void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}