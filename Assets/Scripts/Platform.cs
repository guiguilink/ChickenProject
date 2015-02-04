using UnityEngine;
using System.Collections;
using System;

public class Platform : MonoBehaviour {

    public float timeBetweenRotation;

    bool rotating;
    float timer;
    Quaternion goalRotation;

	// Use this for initialization
	void Start () 
    {
        rotating = false;
        timer = 0f;
	    goalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Rotate") && !rotating && InteractionManager.IsRotateEnable())
        {
            rotating = true;
            goalRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z * -1, transform.rotation.w);
        }

        if (rotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, 0.5f);
            timer += Time.deltaTime;

            if (timer > timeBetweenRotation)
            {
                rotating = false;
                timer = 0f;
            }
        }
	}
}
