using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

    public int powerMax;
    public int offsetPowering;
    public float poweringDelay;
    public GameObject player;

    Vector3 originLauncher;
    float timer;
    int launchForce;
    bool powering;
    
    void Start () 
    {
        originLauncher = transform.position;
        launchForce = 0;
        powering = false;
	}
	

	void Update () 
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire") && launchForce < powerMax)
            Powering();

        if (powering && Input.GetButtonUp("Fire"))
            Launch();
	}

    void Powering()
    {        
        if (timer > poweringDelay * Time.deltaTime)
        {
            if (!powering)
                powering = true;

            launchForce += 1 * offsetPowering;

            transform.position -= new Vector3(0, 1, 0);

            timer = 0f;
        }
    }

    void Launch()
    {
        transform.position = originLauncher;
        player.GetComponent<PlayerManager>().Launch(launchForce);
        powering = false;
        launchForce = 0;
    }
}
