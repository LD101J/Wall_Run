using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Variables
    //float
    [SerializeField] private float move_Speed;
    [SerializeField] private float gravity_Modifier;
    //bool
    public bool is_Grounded;
    [SerializeField] private bool gravity_Switch;
    public bool jump;
    
    [SerializeField] private bool gravity_Run;
    //gravity modifier
    private Rigidbody rb;
    #endregion
    private void Start()
    {
        
        is_Grounded = false;
        gravity_Switch = true;
        rb = GetComponent<Rigidbody>();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        #region Is_Grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_Grounded = true;
            gravity_Switch = false;
            gravity_Run = true;
        }
        #endregion //when is this true
    }
    void Update()
    {
        Upward_Movement();
    }

    private void Upward_Movement()
    {
        if(is_Grounded == true)
            {
            
            transform.Translate(Vector3.up* move_Speed); // uwpwards movement
            if (is_Grounded == true && gravity_Run == true)
            {
                gravity_Run = true;
                if (Input.touchCount > 0)
                    {
                    Jump();
                    gravity_Switch = true;
                    is_Grounded = false;
                    jump = true;
                    gravity_Run = true;

                }
                if (!gravity_Switch)
                {
                    is_Grounded = true;
                    gravity_Switch = false;
                    jump = false;
                }
            }
        }  
    }

    private void Jump()
    {
        Physics.gravity *= -1; // changing gravity
        jump = true;
        gravity_Switch = true;
        gravity_Run = true;
        if(jump == true)
        {
            transform.Rotate(0 , 0, -90);
        }
    }
}
