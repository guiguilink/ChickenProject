using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject levelCamera;
    public GameObject playerCamera;
    public float delayBetweenSwap;

    float timer;
    bool canSwap;
    bool cameraInUse;   // 0 : levelCamera
                        // 1 : playerCamera
	
	// Use this for initialization
	void Start ()
	{
        timer = 0f;
        canSwap = true;
        cameraInUse = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //timer += Time.deltaTime;

        //if (Input.GetButton("SwapCam") && canSwap)
        //    SwapCam();

        //if (timer > delayBetweenSwap)
        //{
        //    canSwap = true;
        //    timer = 0f;
        //}
	}

    void SwapCam()
    {
        canSwap = false;
        cameraInUse = !cameraInUse;

        levelCamera.GetComponent<Camera>().enabled = !cameraInUse;
        playerCamera.GetComponent<Camera>().enabled = cameraInUse;
    }
}
