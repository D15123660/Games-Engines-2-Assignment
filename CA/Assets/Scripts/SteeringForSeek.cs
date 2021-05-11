using UnityEngine;

namespace AI
{
    public class SteeringForSeek : Steering
    {
        //Target Needed to look for
        public GameObject Target;

        //Expected speed
        private Vector3 desiredVelocity;

        //Obtain the controlled AI character
        private Vehicle vehicle;

        //Maximum speed
        private float maxSpeed;

        //Whether to move on a two-dimensional plane
        private bool isPlanar;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;
            isPlanar = vehicle.IsPlannar;
        }

        public override Vector3 Force()
        {
            desiredVelocity = (Target.transform.position
                                - transform.position).normalized * maxSpeed;

            if (isPlanar)
            {
                desiredVelocity.y = 0;
            }

            return desiredVelocity - vehicle.Velocity;
        }
    }
}

