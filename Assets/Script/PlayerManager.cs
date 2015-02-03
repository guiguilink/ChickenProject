using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public float delayBeforeAttenuation;
    public int forceIndexer;
    public int offsetAttenuation;

    Vector3 originPlayer;
    bool launching;
    int force;
    float timer;

	// Use this for initialization
	void Start () 
    {
        originPlayer = transform.position;
        launching = false;
        force = 0;
        timer = 0f;
	}

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (launching && force > 0)
        {
            if (timer > delayBeforeAttenuation)
                force -= offsetAttenuation;

            rigidbody.AddForce(new Vector3(0, force * forceIndexer, 0), ForceMode.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void Launch(int launchForce)
    {
        rigidbody.WakeUp();
        launching = true;
        force = launchForce;
        timer = 0f;
        transform.position = originPlayer;
    }
}
