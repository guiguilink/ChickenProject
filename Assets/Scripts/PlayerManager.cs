using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject levelCamera;
    public float delayBeforeAttenuation;
    public float forceIndexer;
    public int offsetAttenuation;

    Vector3 originPlayer;
    bool launching;
    int launchForce;
    float timer;
    string lastCollectibleGet;

    GameObject expoYellow;
    GameObject expoRed;
    GameObject expoGreen;

	// Use this for initialization
	void Start () 
    {
        originPlayer = transform.position;
        launching = false;
        launchForce = 0;

        timer = 0f;

        expoYellow = GameObject.Find("ExpoYellow");
        expoRed = GameObject.Find("ExpoRed");
        expoGreen = GameObject.Find("ExpoGreen");

        expoYellow.SetActive(false);
        expoRed.SetActive(false);
        expoGreen.SetActive(false);
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
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (levelCamera.GetComponent<LevelCamera>().PlayerBackOrigin)
        {
            transform.position = originPlayer;
            levelCamera.GetComponent<LevelCamera>().PlayerBackOrigin = false;
            GameObject.Destroy(GameObject.Find(lastCollectibleGet + "Prison"));
        }
	}

    public void Launch(int force)
    {
        GetComponent<Rigidbody>().WakeUp();
        launching = true;
        launchForce = force;
        timer = 0f;
        transform.position = originPlayer;
    }

    void OnCollisionEnter(Collision collision)
    {    
        if(collision.gameObject.tag == "Collectible")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();

            if (!audio.isPlaying)
            {
                audio.clip = Resources.Load("Audio/yeah") as AudioClip;
                audio.Play();
            }

            lastCollectibleGet = collision.gameObject.name;
            GameObject.Destroy(collision.gameObject);

            switch (lastCollectibleGet)
            {
                case "Yellow" :
                    expoYellow.SetActive(true);
                    break;
                case "Red":
                    expoRed.SetActive(true);
                    break;
                case "Green":
                    expoGreen.SetActive(true);
                    break;
                default:
                    break;
            }

            levelCamera.GetComponent<LevelCamera>().GetCollectible();
        }
    }
}
