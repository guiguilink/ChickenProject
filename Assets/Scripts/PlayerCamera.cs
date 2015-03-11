using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public GameObject player;

    Vector3 cameraOffset;

	// Use this for initialization
	void Start () 
    {
        cameraOffset = player.transform.position - transform.position;        
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = player.transform.position - cameraOffset;
	}
}
