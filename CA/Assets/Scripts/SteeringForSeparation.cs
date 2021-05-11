using UnityEngine;

namespace AI
{
    public class SteeringForSeparation : Steering
    {
        //Acceptable distance
        public float ComfortDistance = 1;

        //The penalty factor when the AI ​​character is too close to the neighbor
        public float MultiplierInsideComfortDistance = 2;


        public override Vector3 Force()
        {
            Vector3 force = Vector3.zero;

            //Traverse each neighbor in the neighbor list of this AI character
            foreach (var s in GetComponent<Radar>().NeighBors)
            {
                //If s is not the current AI character
                if (s != null && s != gameObject)
                {
                    //Calculate the distance between AI character and neighbor s
                    Vector3 toNeighBor = transform.position - s.transform.position;
                    float length = toNeighBor.magnitude;

                    force += toNeighBor.normalized / length;

                    //If the distance between the two is less than the maximum acceptable distance,
                    //an additional penalty factor is multiplied to make it move away faster
                    if (length < ComfortDistance)
                    {
                        force *= MultiplierInsideComfortDistance;
                    }
                }
            }
            
            return force;
        }
    }
}

