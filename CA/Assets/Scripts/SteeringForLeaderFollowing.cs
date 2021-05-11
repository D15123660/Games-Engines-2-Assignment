using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(SteeringForArrive))]
    public class SteeringForLeaderFollowing : Steering
    {
        private Vector3 target;

        //Leader game object
        public GameObject Leader;

        //Leader's control script
        private Vehicle leaderController;

        //Follow the distance of the trailing leader
        private float LEADERBEHINDDIST = 2.0f;

        private SteeringForArrive steeringForArrive;

        private void Start()
        {
            leaderController = Leader.GetComponent<Vehicle>();

            //Specify a target point for the arrival behavior
            steeringForArrive = GetComponent<SteeringForArrive>();
            
            steeringForArrive.Target = new GameObject("ArriveTarget");

            steeringForArrive.Target.transform.position = Leader.transform.position;
        }

        public override Vector3 Force()
        {
            Vector3 leaderVelocity = leaderController.Velocity;

            //Calculate the target point
            target = Leader.transform.position + LEADERBEHINDDIST
                                                  * (-leaderVelocity).normalized;

            steeringForArrive.Target.transform.position = target;
            
            return Vector3.zero;
        }
    }
}

