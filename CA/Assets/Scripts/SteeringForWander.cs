using UnityEngine;

namespace AI
{
    public class SteeringForWander : Steering
    {
        //Wandering radius, the radius of Wander’s circle
        public float WanderRaius;

        //Wandering distance, the distance the Wander circle protrudes in front of the AI ​​character
        public float WanderDistance;

        //The maximum value of random displacement added to the target per second
        public float WanderJitter;

        public bool IsPlannar;

        private Vehicle vehicle;

        private float maxSpeed;

        private Vector3 circleTarget;

        private Vector3 wanderTarget;
        
        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;
            IsPlannar = vehicle.IsPlannar;

            //Pick a point on the circle as the initial point
            circleTarget = new Vector3(WanderRaius * 0.707f,0,WanderRaius * 0.707f);
        }

        public override Vector3 Force()
        {
            //Calculate random displacement
            Vector3 randomDisplacement = new Vector3
                ((Random.value -0.5f)*2*WanderJitter,
                (Random.value -0.5f)*2*WanderJitter,
                (Random.value -0.5f)*2*WanderJitter);

            if (IsPlannar)
            {
                randomDisplacement.y = 0;
            }

            //Add random displacement to the initial point to get a new position
            circleTarget += randomDisplacement;

            //Since the new position may not be on the circle, it needs to be projected onto the circle
            circleTarget = WanderRaius * circleTarget.normalized;


            //The previously calculated value is relative to the AI ​​character and the forward direction of the AI ​​character,
            //and needs to be converted into world coordinates
            wanderTarget = vehicle.Velocity.normalized * WanderDistance
                            + circleTarget + transform.position;

            //Calculate the expected speed
            Vector3 desiredVelocity = (wanderTarget - transform.position).normalized * maxSpeed;
            
            return desiredVelocity - vehicle.Velocity;
        }

        private void OnDrawGizmos()
        {
//            Gizmos.DrawWireSphere(transform.position, WanderRaius);
//
//            Gizmos.DrawWireSphere(wanderTarget, 3);
        }
    }
}

