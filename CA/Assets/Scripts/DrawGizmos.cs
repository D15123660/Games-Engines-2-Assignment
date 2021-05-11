using AI;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public float EvadeDistance;

    private Vector3 center;
    private Vehicle vehicle;

    private float LEADERBEHINDDIST;
    
    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        LEADERBEHINDDIST = 2.0f;
    }

    void Update()
    {
        center = transform.position + vehicle.Velocity.normalized * LEADERBEHINDDIST;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center, EvadeDistance);
    }
}
