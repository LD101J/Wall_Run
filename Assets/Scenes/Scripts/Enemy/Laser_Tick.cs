using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Tick : MonoBehaviour
{
    [SerializeField] private float look_At;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2.0f;

    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, look_At);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0)
        {
            MoveBetweenWaypoints();
        }
        else
        {
            Debug.LogError("No waypoints assigned to Laser_Tick.");
        }
    }

    void MoveBetweenWaypoints()
    {
        // Move towards the current waypoint
        transform.position = Vector3.Lerp(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Check if the object is close enough to the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Switch to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}