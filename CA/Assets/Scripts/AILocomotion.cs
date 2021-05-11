using UnityEngine;

namespace AI
{
    public class AILocomotion : Vehicle
    {
        // AI character controller
        private CharacterController controller;

        // AI's Rigidbody
        private Rigidbody rigidBody;

        // The distance the AI ​​moves each time
        private Vector3 moveDistance;

        void Start()
        {
            controller = GetComponent<CharacterController>();

            rigidBody = GetComponent<Rigidbody>();
            
            moveDistance = Vector3.zero;
           
            OnStart();
        }

        // The physical operation is updated in this function
        private void FixedUpdate()
        {
            Velocity += acceleration * Time.fixedDeltaTime;

            //Limit maximum speed
            if (Velocity.sqrMagnitude > sqrMaxSpeed)
            {
                Velocity = Velocity.normalized * MaxSpeed;
            }

            moveDistance = Velocity * Time.fixedDeltaTime;

            //Move on the plane
            if (IsPlannar)
            {
                Velocity.y = 0;
                moveDistance.y = 0;
            }

            //Make it move
            if (controller != null)
            {
                controller.SimpleMove(Velocity);
            }
            else if (rigidBody == null || rigidBody.isKinematic)
            {
                transform.position += moveDistance;
            }
            else
            {
                rigidBody.MovePosition(rigidBody.position + moveDistance);
            }

            //Update orientation
            if (Velocity.sqrMagnitude > 0.00001)
            {
                //Calculate new heading by interpolation of current heading and speed direction
                Vector3 newForward = Vector3.Slerp(transform.forward,
                    Velocity, Damping * Time.deltaTime);
                
                if (IsPlannar)
                {
                    newForward.y = 0;
                }

                transform.forward = newForward;
            }
        }
        
    }
}

