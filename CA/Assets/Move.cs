using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public class Path
    {
        public Transform Poitn;
        public float MoveTime;
        public float WaitTime;
        public Vector3 Speed;
    }

    public Path[] path = new Path[0];
    private int Id;
    public Transform target;

    void Start()
    {
        
        target.position = path[0].Poitn.position;
        
        for (int i = 1; i < path.Length; i++)
        {
            path[i].Speed = (path[i].Poitn.position - path[i - 1].Poitn.position) / path[i].MoveTime;
        }
    }

    void Update()
    {
        if (Id < path.Length)
        {
            Path p = path[Id];
           
            if (p.MoveTime > 0)
            {
                p.MoveTime -= Time.deltaTime;
                target.position += p.Speed * Time.deltaTime;
            }
            else
            {
                
                target.position = p.Poitn.position;
                if (p.WaitTime > 0)
                {
                    p.WaitTime -= Time.deltaTime;
                }
                else
                {
                    Id++;
                }
            }
        }
    }
    
}
