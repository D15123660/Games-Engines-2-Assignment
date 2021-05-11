using UnityEngine;

namespace AI
{
    public class SteeringFollowPath : Steering
    {
        //Path node array
        public GameObject[] WayPoints = new GameObject[4];


        //Target
        private Transform target;

        //Current waypoint index
        private int currentNode;

        //When the distance to the waypoint is less than this value,
        //it is considered to have arrived and can be triggered to the next point
        private float arriveDistance;
        private float sqrArriveDistance;

        //Number of waypoints
        private int numberOfNodes;
        
        private Vehicle vehicle;

        private float maxSpeed;

        private bool isPlanar;

        //Start to slow down when the distance to the target is less than this distance
        public float SlowDownDistance;
        
        void Start()
        {
            numberOfNodes = WayPoints.Length;
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;
            isPlanar = vehicle.IsPlannar;

            //Set the current waypoint as the 0th waypoint
            currentNode = 0;

            target = WayPoints[currentNode].transform;
            
            arriveDistance = 1.0f;

            sqrArriveDistance = arriveDistance * arriveDistance;
        }

        public override Vector3 Force()
        {
            Vector3 force = Vector3.zero;
            Vector3 desiredVelocity;

            Vector3 dist = target.position - transform.position;

            if (isPlanar)
            {
                dist.y = 0;
            }

            //If the current waypoint is already the last
            if (currentNode == numberOfNodes - 1)
            {
                //If the distance from the current waypoint is greater than the deceleration distance
                if (dist.magnitude > SlowDownDistance)
                {
                    desiredVelocity = dist.normalized * maxSpeed;

                    force = desiredVelocity - vehicle.Velocity;
                }
                else
                {
                    //The distance to the current waypoint is less than the deceleration distance,
                    //start to decelerate, and calculate the control vector
                    desiredVelocity = dist - vehicle.Velocity;

                    force = desiredVelocity - vehicle.Velocity;
                }
            }
            else
            {
                //The current waypoint is not the last waypoint, judge whether it is within the reach
                if (dist.sqrMagnitude < sqrArriveDistance)
                {
                    //Already within the reach, set the next waypoint as the target point
                    currentNode++;

                    target = WayPoints[currentNode].transform;
                }
                else
                {
                    desiredVelocity = dist.normalized * maxSpeed;
                    force = desiredVelocity - vehicle.Velocity;
                }
            }

            return force;
        }

        private void OnDrawGizmos()
        {
            if (WayPoints == null)
            {
                return;
            }
            
            foreach (var wayPoint in WayPoints)
            {
                Gizmos.DrawWireSphere(wayPoint.transform.position, SlowDownDistance);
            }
        }
    }
}
