using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

    public Vector3 launchPosition;
    public Vector3 levelPosition;
    public float speedCameraTranslation;

    bool launching;
    bool gettingCollectible;
    bool playerBackOrigin;
    float timer;

    // Use this for initialization
    void Start()
    {
        launching = false;
        gettingCollectible = false;
        playerBackOrigin = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (launching)
            ToLevelZone();

        if(gettingCollectible)
            ToLaunchZone();
    }

    void ToLaunchZone()
    {
        timer += Time.deltaTime;

        if (timer > 1.0f)
        {
            transform.position = Vector3.Lerp(transform.position, launchPosition, speedCameraTranslation);

            if (Mathf.Round(transform.position.z) == Mathf.Round(launchPosition.z))
            {
                gettingCollectible = false;
                playerBackOrigin = true;
                timer = 0f;
            }
        }
    }

    void ToLevelZone()
    {
        transform.position = Vector3.Lerp(transform.position, levelPosition, speedCameraTranslation);

        if (Mathf.Round(transform.position.z) == Mathf.Round(levelPosition.z))
            launching = false;
    }

    public void Launch()
    {
        launching = true;
    }

    public void GetCollectible()
    {
        gettingCollectible = true;
    }

    public bool PlayerBackOrigin
    {
        get { return playerBackOrigin; }
        set { playerBackOrigin = value; }
    }
}
