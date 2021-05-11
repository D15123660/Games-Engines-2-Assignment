using UnityEngine;

namespace AI
{
    public class SteeringForCollisionAvoidanceQueue : Steering
    {
        public bool IsPlanar;
        
        private Vehicle vehicle;
        
        private float maxForce;

        public float AvoidanceForce;

        public float MAXSEEHEAD;

        private LayerMask layerMask;
        
        void Start()
        {
            vehicle = GetComponent<Vehicle>();
            
            maxForce = vehicle.MaxForce;

            IsPlanar = vehicle.IsPlannar;

            if (AvoidanceForce > maxForce)
            {
                AvoidanceForce = maxForce;
            }

            int layerId = LayerMask.NameToLayer("Obstacle");
            layerMask = 1 << layerId;
        }

        public override Vector3 Force()
        {
            Vector3 force = Vector3.zero;
            Vector3 velocity = vehicle.Velocity;
            Vector3 normalizedVelocity = velocity.normalized;

            if (Physics.Raycast(transform.position, normalizedVelocity,
                out var hit, MAXSEEHEAD, layerMask))
            {
                Vector3 ahead = transform.position + normalizedVelocity * MAXSEEHEAD;

                force = ahead - hit.collider.transform.position;
                force *= AvoidanceForce;

                if (IsPlanar)
                {
                    force.y = 0;
                }
            }

            return force;
        }
    }
}
