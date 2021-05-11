using System.Collections.Generic;
using AI;
using UnityEngine;

public class Radar : MonoBehaviour
{
    //Array of collision bodies
    private Collider[] colliders;

    //Timer
    private float timer = 0;

    //Neighbor list
    public List<GameObject> NeighBors;

    //Detection interval
    public float CheckInterval = 0.3f;

    //Detection radius
    public float DetectRadius = 10;

    //Set which level of game object is detected
    public LayerMask LayerChecked;

    private void Start()
    {
        NeighBors = new List<GameObject>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //If the time since the last detection is greater than the set detection time interval, then re-detect
        if (timer > CheckInterval)
        {
            //Clear neighbor list
            NeighBors.Clear();

            //Find all collision objects in the neighborhood of the current AI character
            colliders = Physics.OverlapSphere(transform.position, DetectRadius, LayerChecked);

            for (int i = 0,count = colliders.Length; i < count; i++)
            {
                var colliderItem = colliders[i];
                if (colliderItem.GetComponent<Vehicle>())
                {
                    NeighBors.Add(colliderItem.gameObject);
                }
            }

            timer = 0;
        }
    }
}
