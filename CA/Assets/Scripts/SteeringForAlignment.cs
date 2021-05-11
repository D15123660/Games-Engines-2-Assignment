using UnityEngine;

namespace AI
{
    public class SteeringForAlignment : Steering
    {
        public override Vector3 Force()
        {
            //The average orientation of the neighbors of the current AI character
            Vector3 averageDirection = Vector3.zero;

            //Number of neighbors
            int neighBorCount = 0;

            foreach (var s in GetComponent<Radar>().NeighBors)
            {
                //If it is not the current character
                if (s != null && s != gameObject)
                {
                    //Add the orientation vector of s to the averageDirection
                    averageDirection += s.transform.forward;

                    //Number of neighbors
                    neighBorCount++;
                }
            }
            
            if (neighBorCount > 0)
            {
                //Divide the accumulated direction vector by the number of neighbors to find the average direction vector
                averageDirection /= (float) (neighBorCount);

                //Average heading vector minus current heading vector to get control vector
                averageDirection -= transform.forward;
            }

            return averageDirection;
        }
    }
}

