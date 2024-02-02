using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Changer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool is_Grounded;
    [SerializeField] private bool is_Switching;
    [SerializeField] private float z_RotationSpeed = 90f;
    [SerializeField] private bool rotateClockwise = true; // Added variable to track rotation direction
    private void Awake()
    {
        gameObject.transform.Rotate(0, 0, 90);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        is_Grounded = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            is_Grounded = true;
        }
    }

    void Update()
    {
        Switch_Gravity();
        RotateObject();
    }

    void Switch_Gravity()
    {
        if (Input.touchCount > 0 && is_Grounded)
        {
            is_Switching = true;
            is_Grounded = false;
            rb.gravityScale *= -1;
            rotateClockwise = !rotateClockwise; // Toggle rotation direction on tap
        }
        else
        {
            is_Switching = false;
        }
    }

    void RotateObject()
    {
        if (is_Switching)
        {
            float rotationAmount = rotateClockwise ? -90f : 90f;
            transform.eulerAngles = new Vector3(0,0,-90);
        }
        
    }
}