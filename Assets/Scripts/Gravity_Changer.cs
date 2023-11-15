using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Changer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool is_Switching;
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
            is_Switching = false;
            if (is_Grounded)
            {
                is_Switching = false;
            }
            if (is_Switching)
            {
                is_Grounded = false;
            }
        }
        
    }

    void Update()
    {
        Switch_Gravity();
    }

    private void Switch_Gravity()
    {
        if (Input.touchCount > 0 && is_Grounded)
        {
            is_Switching = true;
            is_Grounded = false;
            rb.gravityScale *= -1;
        }
        else
        {
            is_Switching = false;
        }
    }
}