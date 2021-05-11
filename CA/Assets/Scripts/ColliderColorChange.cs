using AI;
using UnityEngine;

public class ColliderColorChange : MonoBehaviour
{
    private Renderer renderer;
    
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If a collision is triggered
        if (other.gameObject.GetComponent<Vehicle>() != null)
        {
            renderer.material.color = Color.red;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        renderer.material.color = Color.white;
    }
}
