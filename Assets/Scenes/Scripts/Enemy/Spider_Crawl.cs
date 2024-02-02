using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Crawl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float move_Speed;
    [SerializeField] private bool ground_Detected;
    [SerializeField] private bool has_Turn;
    [SerializeField] private Transform groundPos_Checker;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIs_Ground;
    [SerializeField] private float y_Rotation;
    [SerializeField] private float z_Rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Check_Ground();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Check_Ground()
    {
        ground_Detected = Physics2D.Raycast(groundPos_Checker.position, -transform.up, groundCheckDistance, whatIs_Ground);
        if (!ground_Detected)
        {
            transform.eulerAngles = new Vector3(0, y_Rotation, -z_Rotation);
        }
    }
    void Movement()
    {
        rb.velocity = -transform.right * move_Speed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPos_Checker.position, new Vector2(groundPos_Checker.position.x + groundCheckDistance, groundPos_Checker.position.y));
    }
}
