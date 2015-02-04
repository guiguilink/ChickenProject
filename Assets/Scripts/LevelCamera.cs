using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

    public Vector3 launchPosition;
    public Vector3 levelPosition;
    public float speedCameraTranslation;

    bool launching;

    // Use this for initialization
    void Start()
    {
        launching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (launching)
        {
            transform.position = Vector3.Lerp(transform.position, levelPosition, speedCameraTranslation);
        }
    }

    public void Launch()
    {
        launching = true;
    }
}
