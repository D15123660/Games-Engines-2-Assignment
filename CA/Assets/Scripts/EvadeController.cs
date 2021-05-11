using AI;
using UnityEngine;

public class EvadeController : MonoBehaviour
{

    public GameObject Leader;

    private Vehicle leaderLocomotion;

    private Vehicle vehicle;

    private bool isPlanar;

    private Vector3 leaderAhead;

    private float LEADERBEHINDDIST;

    private Vector3 dist;

    public float EvadeDistance;

    private float sqrEvadeDistance;

    private SteeringForEvade steeringForEvade;

    private void Start()
    {
        leaderLocomotion = Leader.GetComponent<Vehicle>();

        steeringForEvade = GetComponent<SteeringForEvade>();

        vehicle = GetComponent<Vehicle>();

        isPlanar = vehicle.IsPlannar;

        LEADERBEHINDDIST = 2.0f;

        sqrEvadeDistance = EvadeDistance * EvadeDistance;
    }

    private void Update()
    {
        //Calculate a point in front of the leader
        leaderAhead = Leader.transform.position + leaderLocomotion
                           .Velocity.normalized * LEADERBEHINDDIST;

        //Calculate the distance between the current position and the point in front of the leader,
        //if it is less than a certain value, you need to avoid
        dist = transform.position - leaderAhead;

        if (isPlanar)
        {
            dist.y = 0;
        }

        if (dist.sqrMagnitude < sqrEvadeDistance)
        {
            //If it is less than the avoidance distance, activate the avoidance behavior
            steeringForEvade.enabled = true;
            Debug.DrawLine(transform.position, Leader.transform.position);
        }
        else
        {
            steeringForEvade.enabled = false;
        }
    }
}
