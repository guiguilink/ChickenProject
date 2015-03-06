using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public float delayBeforeAttenuation;
    public float forceIndexer;
    public int offsetAttenuation;

    Vector3 originPlayer;
    bool launching;
    bool rolling;
    int launchForce;
    float rollingForce;
    float timer;

	// Use this for initialization
	void Start () 
    {
        originPlayer = transform.position;
        launching = false;
        rolling = false;
        launchForce = 0;
        rollingForce = 0f;
        timer = 0f;
	}

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (launching && launchForce > 0)
        {
            if (timer > delayBeforeAttenuation)
                launchForce -= offsetAttenuation;

            GetComponent<Rigidbody>().AddForce(new Vector3(0, launchForce * forceIndexer, 0), ForceMode.Impulse);
        }

        if(rolling)
        {
            rollingForce += 0.1f;
            //GetComponent<Rigidbody>().AddForce(new Vector3(rollingForce, 0, 0), ForceMode.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void Launch(int force)
    {
        GetComponent<Rigidbody>().WakeUp();
        launching = true;
        launchForce = force;
        timer = 0f;
        transform.position = originPlayer;
    }

    void OnCollisionEnter(Collision collision){
        if (!rolling)
            rolling = true;
        else if(collision.gameObject.tag == "Collectible")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();

            if (!audio.isPlaying)
            {
                audio.clip = Resources.Load("Audio/yeah") as AudioClip;
                audio.Play();
                GameObject.Destroy(collision.gameObject);
            }
        }
    }

    void OnCollisionExit(Collision collision){
        if(rolling)
            rolling = false;

        rollingForce = 0;
    }
}
