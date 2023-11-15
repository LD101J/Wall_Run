using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Changer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isSwitching;
    [SerializeField] private bool is_Grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_Grounded = true;
            isSwitching = false;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            is_Grounded = false;
            isSwitching = true;
            rb.gravityScale *= -1;
        }
    }
}