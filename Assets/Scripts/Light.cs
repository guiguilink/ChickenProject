using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {

    public float offsetRotation;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, offsetRotation, 0));

        if (transform.rotation.eulerAngles.y < 300 || transform.rotation.eulerAngles.y > 400)
            offsetRotation *= -1;
	}
}
