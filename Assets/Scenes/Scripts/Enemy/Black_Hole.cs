using UnityEngine;

public class Black_Hole : MonoBehaviour
{
    public Transform vacuum;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    public float attractionDistance = 10f;
    public float scaleDownFactor = 0.03f;

    private Transform myTransform;
    private bool isMoving = false;
    private Vector3 originalScale;

    private void Awake()
    {
        myTransform = transform;
        originalScale = myTransform.localScale;
    }

    private void Update()
    {
        float distance = Vector3.Distance(myTransform.position, vacuum.position);

        if (distance <= attractionDistance)
        {
            if (!isMoving)
            {
                isMoving = true;

                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(vacuum.position - myTransform.position), rotationSpeed * Time.deltaTime);
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

                float scaleMultiplier = Mathf.Clamp01(1 - distance / attractionDistance);
                myTransform.localScale = originalScale * scaleMultiplier;
            }
        }
        else
        {
            isMoving = false;

            // Slowly grow back to original scale if not being attracted by the vacuum
            myTransform.localScale = Vector3.Lerp(myTransform.localScale, originalScale, 0.01f);
        }
    }

    // You can uncomment this if you want a collision event with a specific tag
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}