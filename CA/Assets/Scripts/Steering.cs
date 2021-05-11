using UnityEngine;

namespace AI
{
    public abstract class Steering : MonoBehaviour
    {
        public float Weight = 1;

        private void Start()
        {

        }

        private void Update()
        {

        }

        public virtual Vector3 Force()
        {
            return new Vector3();
        }
    }
}

