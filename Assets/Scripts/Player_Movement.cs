using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Variables
    //float
    [SerializeField] private float move_Speed;
    [SerializeField] private float jump_Force;
    //bool
    private bool is_Grounded;
    private bool gravity_Switch;
    private bool jump;
    private bool gravity_Run;
    //gravity modifier
    private Rigidbody2D rb;
    #endregion

    private void Start()
    {
        is_Grounded = false;
        gravity_Switch = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_Grounded = true;
            gravity_Switch = false;
            gravity_Run = true;
        }
    }

    void Update()
    {
        Upward_Movement();

        // Check for touches each frame
        DetectTouches();
    }

    private void Upward_Movement()
    {
        if (is_Grounded)
        {
            // Apply upward force instead of translating
            rb.velocity = new Vector2(rb.velocity.x, move_Speed);

            // Remove the touch condition from here
        }
    }

    private void DetectTouches()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_Grounded && !jump)
        {
            Jump();
        }
        else
        {

        }
    }

        private void Jump()
    {
        // Reset vertical velocity before applying jump force
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // Apply jump force
        //rb.AddForce(Vector2.up * jump_Force, ForceMode2D.Impulse);
        //Physics2D.gravity *= -1;
        rb.gravityScale *= 1;
        jump = true;
        gravity_Switch = true;
        gravity_Run = true;
    }
}