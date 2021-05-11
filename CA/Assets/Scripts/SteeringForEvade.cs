using UnityEngine;

namespace AI
{
    public class SteeringForEvade : Steering
    {
        public GameObject Target;

        private Vehicle vehicle;

        private Vehicle targetVehicle;

        private float maxSpeed;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;

            targetVehicle = Target.GetComponent<Vehicle>();
        }

        public override Vector3 Force()
        {
            Vector3 toTarget = Target.transform.position - transform.position;


            //Forecast time
            float lookaheadTime = toTarget.magnitude / (maxSpeed + targetVehicle.Velocity.magnitude);

            //Expected speed
            Vector3 desiredVelocity =
                (transform.position - (Target.transform.position + targetVehicle.Velocity * lookaheadTime))
                .normalized * maxSpeed;
            
            return desiredVelocity - vehicle.Velocity;
        }
    }
}

