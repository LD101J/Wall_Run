using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int max_Health = 100;
    [SerializeField] private float current_Health;
    [SerializeField] private Gravity_UI current_Gravity;
    // Start is called before the first frame update
    void Start()
    {
        current_Health = max_Health;
        current_Gravity.Set_Max_Health(max_Health); 
    }

    // Update is called once per frame
    void Update()
    {
        Reduce_Health();
    }

    private void Reduce_Health()
    {
        current_Health = Time.timeScale;
       // current_Gravity.Set_Health(current_Health);
    }
}
