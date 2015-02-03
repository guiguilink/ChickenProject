using UnityEngine;
using System.Collections;
using System;

public class Platform : MonoBehaviour {

    bool rotating;
    Quaternion goalRotation;

	// Use this for initialization
	void Start () 
    {
        rotating = false;
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
            decimal platZRot = Math.Round((Decimal)transform.rotation.z, 3, MidpointRounding.AwayFromZero);
            decimal goalZRot = Math.Round((Decimal)goalRotation.z, 3, MidpointRounding.AwayFromZero);

            transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, 0.5f);

            if (platZRot == goalZRot)
                rotating = false;
        }
	}
}
