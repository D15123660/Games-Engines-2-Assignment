using UnityEngine;

namespace AI
{
    public class SteeringForFlee : Steering
    {
        public GameObject Target;

        //The range that makes the AI ​​character aware of danger and start to escape
        public float FearDistance = 20;

        private Vector3 desiredVelocity;

        private Vehicle vehicle;

        private float maxSpeed;

        private float sqrFearDistance;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            maxSpeed = vehicle.MaxSpeed;

            sqrFearDistance = FearDistance * FearDistance;
        }

        public override Vector3 Force()
        {
            Vector3 tmpPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 tmpTargetPos = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);

            //If the distance between the AI ​​character and the target is greater than the escape distance, then there is no force
            if (Vector3.SqrMagnitude(tmpPos - tmpTargetPos) > sqrFearDistance)
            {
                return Vector3.zero;
            }

            desiredVelocity = (transform.position - Target.transform.position).normalized * maxSpeed;
            return desiredVelocity - vehicle.Velocity;
        }
    }
}

