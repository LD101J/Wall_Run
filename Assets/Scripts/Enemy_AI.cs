using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy_AI : MonoBehaviour
{
    //transform
    [SerializeField] private Transform target;
    //bool
    [SerializeField] private bool is_Provoked;
    //floats
    [SerializeField] private float chase_Range;
    [SerializeField] private float rotate_Speed;
    private float distance_To_Target = Mathf.Infinity;
    private NavMeshAgent nav_Mesh;

    private void Start()
    {
        nav_Mesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        distance_To_Target = Vector2.Distance(target.position, transform.position);

        if (is_Provoked)
        {
            Engage_Target();
        }
        else if (distance_To_Target <= chase_Range)
        {
            is_Provoked = true;

        }
    }

    private void Engage_Target()
    {
        Face_Target();
        if (distance_To_Target >= nav_Mesh.stoppingDistance)
        {
            Chase_Target();
        }
        if (distance_To_Target <= nav_Mesh.stoppingDistance)
        {
            //GetComponent<Animator>().SetBool("Attack", true);
            Attack_Target();
        }
}

    private void Face_Target()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector2(direction.x, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotate_Speed);
    }

    private void Chase_Target()
    {
        is_Provoked = true;
        //GetComponent<Animator>().SetTrigger("Move");//going into the move animation
        //GetComponent<Animator>().SetBool("Attack", false);
        //nav_Mesh.SetDestination(target.position);//nav mesh will travel to the players position
    }

    private void Attack_Target()
    {
        Debug.Log(name + "fuck" + target.name);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, chase_Range);
    }

}
