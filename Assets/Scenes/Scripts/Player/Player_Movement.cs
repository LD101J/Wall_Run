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
    //gizmos
    [SerializeField] private float player_Range = 5f;
    #endregion

    private void Start()
    {
        is_Grounded = false;
        gravity_Switch = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject on the "ground" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            is_Grounded = true;
            gravity_Switch = false;
            gravity_Run = true;
        }
    }

    void Update()
    {
        Upward_Movement();
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
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, player_Range);
    //}
}