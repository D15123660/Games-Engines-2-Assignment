using UnityEngine;

namespace AI
{
    public class SteeringForPursuit : Steering
    {
        public GameObject Target;
        
        private Vehicle vehicle;

        private float maxSpeed;

        private Vehicle targetVehicle;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;

            targetVehicle = Target.GetComponent<Vehicle>();
        }

        public override Vector3 Force()
        {
            Vector3 toTarget = Target.transform.position - transform.position;

            //Calculate the angle between the forward direction of the chaser and the forward direction of the evader
            float relationDirection = Vector3.Dot(transform.forward, Target.transform.forward);

            Vector3 desiredVelocity;

            //If the angle is greater than 0, and the chaser basically faces the evader,
            //then move directly to the current position of the evader
            if ((Vector3.Dot(toTarget, transform.forward) > 0) && relationDirection < -0.95f)
            {
                desiredVelocity = (Target.transform.position - transform.position).normalized * maxSpeed;

                return (desiredVelocity - vehicle.Velocity);
            }

            //Calculate the prediction time, which is proportional to the distance between the chaser and the evader,
            //and inversely proportional to the speed and the speed of the chaser and the evader.
            float lookaheadTime = toTarget.magnitude / (maxSpeed + targetVehicle.Velocity.magnitude);
            desiredVelocity = (Target.transform.position + targetVehicle.Velocity * lookaheadTime -
                 transform.position).normalized * maxSpeed;

            return desiredVelocity - vehicle.Velocity;
        }
    }
}
