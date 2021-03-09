using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantMove : MonoBehaviour
{	
    public Transform sun;
    public Transform mercury;
    public Transform venus;
    public Transform earth;
    public Transform mars;
    public Transform jupiter;
    public Transform saturn;
    public Transform uranus;
    public Transform neptune;
    public Transform moon;
    public Transform earthclone;
    // Use this for initialization  
    void Start()
    {

    }
    // Update is called once per frame  
    void FixedUpdate()
    {
	    mercury.RotateAround(this.transform.position, new Vector3(3, 15, 0), 470 * Time.deltaTime);
	    mercury.Rotate(Vector3.up * Time.deltaTime * 300);
	    venus.RotateAround(this.transform.position, new Vector3(2,10, 0), 350 * Time.deltaTime);
	    venus.Rotate(Vector3.up * Time.deltaTime * 280);
	    earth.RotateAround(this.transform.position, new Vector3(1, 10, 0), 300 * Time.deltaTime);
	    earth.Rotate(Vector3.up * Time.deltaTime * 250);
	    mars.RotateAround(this.transform.position, new Vector3(2, 15, 0), 240 * Time.deltaTime);
	    mars.Rotate(Vector3.up * Time.deltaTime * 220);
	    jupiter.RotateAround(this.transform.position, new Vector3(2, 10, 0), 130 * Time.deltaTime);
	    jupiter.Rotate(Vector3.up * Time.deltaTime * 180);
	    saturn.RotateAround(this.transform.position, new Vector3(1, 15, 0), 90 * Time.deltaTime);
	    saturn.Rotate(Vector3.up * Time.deltaTime * 160);
	    uranus.RotateAround(this.transform.position, new Vector3(2, 5, 0), 60 * Time.deltaTime);
	    uranus.Rotate(Vector3.up * Time.deltaTime * 150);
	    neptune.RotateAround(this.transform.position, new Vector3(3, 10, 0), 50 * Time.deltaTime);
	    neptune.Rotate(Vector3.up * Time.deltaTime * 140);
	    earthclone.RotateAround(this.transform.position, new Vector3(1, 10, 0), 300 * Time.deltaTime);
	    moon.transform.RotateAround (earthclone.transform.position, new Vector3(1, 12, 0), 500 * Time.deltaTime);

    }
}