using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Run : MonoBehaviour
{
    #region Variables
    //float
    [SerializeField] private float xAxis;
    [SerializeField] private float zAxis;
    //bool
    public bool rightWall;
    public bool leftWall;
    #endregion
    private void Start()
    {
        Going_RWall();
        transform.Rotate(xAxis, 0, zAxis);
    }
    private void Going_RWall()
    {
        //rightWall = true;
        //leftWall = false;
    }
}
