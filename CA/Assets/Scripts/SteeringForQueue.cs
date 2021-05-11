using UnityEngine;

namespace AI
{
    public class SteeringForQueue : Steering
    {
        public float MAXQUEUEAHEAD;
        public float MAXQUEUERADIUS;

        public float VelocityReduceFactor = 0.3f;
        
        private Collider[] colliders;
        
        private Vehicle vehicle;

        private LayerMask layerMask;

        void Start()
        {
            vehicle = GetComponent<Vehicle>();

            //Set the mask for collision detection
            int layerId = LayerMask.NameToLayer("Vehicles");

            layerMask = 1 << layerId;
        }

        public override Vector3 Force()
        {
            Vector3 velocity = vehicle.Velocity;
            Vector3 normalizedVelocity = velocity.normalized;

            //Calculate the point in front of the character
            Vector3 ahead = transform.position + normalizedVelocity * MAXQUEUEAHEAD;

            //If you take ahead as the center of the circle, there are other characters in the MAXQUEUERADIUS ball

            colliders = Physics.OverlapSphere(ahead, MAXQUEUERADIUS, layerMask);
            if (colliders.Length > 0)
            {
                //For all other characters in the sphere, if their speed is slower than the current character
                //The current character’s speed slows down to avoid collisions
                foreach (var c in colliders)
                {
                    float sqrOtherVelocityLength = c.gameObject.GetComponent<Vehicle>().Velocity.sqrMagnitude;
                    if (c.gameObject != gameObject && sqrOtherVelocityLength < velocity.sqrMagnitude)
                    {
                        vehicle.Velocity *= VelocityReduceFactor;
                        break;
                    }
                }
            }

            return Vector3.zero;
        }
    }

}
