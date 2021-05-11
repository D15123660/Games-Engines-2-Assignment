using UnityEngine;

namespace AI
{
    public class Vehicle : MonoBehaviour
    {
        //List of manipulation behaviors included in this AI character
        private Steering[] steerings;

        //Set the maximum speed that the character can reach
        public float MaxSpeed = 10;

        //Set the maximum force that can be applied to this AI character
        public float MaxForce = 100;

        //The square of the maximum speed is calculated and stored in advance to save resources
        protected float sqrMaxSpeed;

        //AI Mass
        public float Mass = 1;

        //AI qualityAI speed
        public Vector3 Velocity;

        //Control the speed when turning
        public float Damping = 0.9f;

        //The calculation interval of the control force, in order to achieve a higher frame rate,
        //the control force does not need to be updated every frame
        public float ComputeInterval = 0.2f;

        //Whether it is on a two-dimensional plane, if so,
        //ignore the difference in y value when calculating the distance between two GameObjects
        public bool IsPlannar = true;

        //Calculated control force
        private Vector3 steeringForce;

        //AI character acceleration
        protected Vector3 acceleration;

        //Timer
        private float timer;

        protected void OnStart()
        {
            steeringForce = Vector3.zero;
            sqrMaxSpeed = MaxSpeed * MaxSpeed;
            timer = 0;
            steerings = GetComponents<Steering>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            steeringForce = Vector3.zero;

            //If the time since the last calculation of the control force is greater than the set time interval
            //Calculate the control force again
            if (timer > ComputeInterval)
            {
                foreach (var steering in steerings)
                {
                    if (steering.enabled)
                    {
                        steeringForce += steering.Force() * steering.Weight;
                    }
                }

                //Control force cannot be greater than MaxForce
                steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);

                //Divide the force by the mass to find the acceleration
                acceleration = steeringForce / Mass;

                //The timer returns to 0
                timer = 0;
            }
        }
    }
}

