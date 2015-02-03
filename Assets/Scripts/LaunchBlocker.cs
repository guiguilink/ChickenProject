using UnityEngine;
using System.Collections;
using System;

public class LaunchBlocker : MonoBehaviour {

    bool blocking;
    bool animationEnd;
    Vector3 goalScale;

	// Use this for initialization
	void Start () 
    {
	    blocking = false;
        animationEnd = false;
        goalScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (blocking && !animationEnd)
            AnimateBlock();
	}

    private void AnimateBlock()
    {
        decimal platZSca = Math.Round((Decimal)transform.localScale.z, 3, MidpointRounding.AwayFromZero);
        decimal goalZSca = Math.Round((Decimal)goalScale.z, 3, MidpointRounding.AwayFromZero);

        transform.localScale = Vector3.Lerp(transform.localScale, goalScale, 0.05f);

        if (platZSca == goalZSca)
            animationEnd = true;
    }

    public void Block()
    {
        blocking = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void UnBlock()
    {
        blocking = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
