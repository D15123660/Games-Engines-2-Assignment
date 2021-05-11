using UnityEngine;

namespace AI
{
    public class SteeringForCohesion : Steering
    {
        private Vector3 desiredVelocity;

        private Vehicle vehicle;

        private float maxSpeed;

        private void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;
        }

        public override Vector3 Force()
        {
            Vector3 force = Vector3.zero;

            //The center of mass of all neighbors of the AI ​​character, that is the average position
            Vector3 centerOfMass = Vector3.zero;

            //The number of neighbors of the AI ​​character
            int neighborCount = 0;

            foreach (var s in GetComponent<Radar>().NeighBors)
            {
                //If s is not the current AI character
                if (s != null && s != gameObject)
                {
                    //Position of accumulated s
                    centerOfMass += s.transform.position;

                    //Increase in the number of neighbors
                    neighborCount++;
                }
            }

            if (neighborCount > 0)
            {
                //Get the average
                centerOfMass /= (float) neighborCount;
            }

            //The expected speed is the difference between the average location of the neighbors and the current speed
            desiredVelocity = (centerOfMass - transform.position).normalized * maxSpeed;

            //The expected speed minus the current speed to find the steering vector
            force = desiredVelocity - vehicle.Velocity;
            
            return force;
        }
    }
}

