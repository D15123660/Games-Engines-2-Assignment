using UnityEngine;

namespace AI
{
    public class SteeringForArrive : Steering
    {
        public bool IsPlanar = true;

        //When the target is less than this distance, start to slow down
        public float SlowDownDistance;

        public GameObject Target;

        private Vehicle vehicle;

        private float maxSpeed;

        private float sqrSlowDownDistance;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;
            IsPlanar = vehicle.IsPlannar;
            sqrSlowDownDistance = SlowDownDistance * SlowDownDistance;
        }

        public override Vector3 Force()
        {
            //Calculate the distance between the AI ​​character and the target
            Vector3 toTarget = Target.transform.position - transform.position;

            //Expected speed
            Vector3 desiredVelocity;

            //Returned manipulation vector
            Vector3 returnForce;
            if (IsPlanar)
            {
                toTarget.y = 0;
            }

            float distance = toTarget.sqrMagnitude;

            //The distance to the target is greater than the set deceleration radius
            if (distance > sqrSlowDownDistance)
            {
                desiredVelocity = toTarget.normalized * maxSpeed;
                returnForce = desiredVelocity - vehicle.Velocity;
            }
            else
            {
                desiredVelocity = toTarget - vehicle.Velocity;
                returnForce = desiredVelocity - vehicle.Velocity;
            }
            

            return returnForce;
        }

        private void OnDrawGizmos()
        {
            if (Target == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(Target.transform.position, SlowDownDistance);
        }
    }
}

