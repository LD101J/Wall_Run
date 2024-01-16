using UnityEngine;
using UnityEngine.UI;

public class Gravity_UI_New : MonoBehaviour
{
    [SerializeField] private float maxGravity = 100f;
    [SerializeField] private float playerGravity;
    [SerializeField] private float gravityDecrementRate;
    [SerializeField] private Image gravityUIImage;
    [SerializeField] private float spike;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            playerGravity -= spike;
            UpdateUI(); // Call UpdateUI here to update the UI when gravity changes due to spike
        }
    }
}