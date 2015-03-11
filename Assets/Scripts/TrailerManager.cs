using UnityEngine;
using System.Collections;

public class TrailerManager : MonoBehaviour {

    public GameObject player;

    int step;
    float timer;

	// Use this for initialization
	void Start () 
    {
        timer = 0f;
        step = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {        
        timer += Time.deltaTime;
        
        /* Launch Part*/
        if (timer > 2.0f && step == 0)
        {
            transform.position += new Vector3(0, 0, 2);
            step++;
        }
        else if (timer > 4f && step == 1)
        {
            transform.position += new Vector3(0, 0, 2);
            step++;
        }
        else if (timer > 6f && step == 2)
        {
            transform.position += new Vector3(0, 0, 1);
            step++;
        }
        else if (timer > 7.5f)
        {
            transform.LookAt(player.transform);
        }

        /* AllChicken Part
        transform.position += new Vector3(0.035f, 0, 0);*/

        /* Snake Part
        if (timer > 1.5f && timer < 3f)
            transform.position += new Vector3(0, 0.02f, 0);
        else if (timer > 3f && timer < 4.5f)
        {
            if(step == 0)
            {
                transform.position = new Vector3(-2f, 170.06f, -1.5f);
                step++;
            }

            transform.position += new Vector3(0.02f, 0, 0);
        }
        else if(timer > 4.5f && transform.position.z > -20f)
        {
            if (step == 1)
            {
                transform.position = new Vector3(0, 159f, -1.5f);
                step++;
            }

            transform.position -= new Vector3(0, 0, 0.2f);
        }*/

        /* LavaPart
        transform.LookAt(player.transform);

        if(timer > 1.3f && timer < 2f)
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles + new Vector3(-1f, 0, 0));
        else if(timer > 2.5f && timer  < 3.2f)
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles + new Vector3(1f, 0, 0));
        else if(timer > 3.7f)
        {
            if (step == 0)
            {
                player.GetComponent<Rigidbody>().useGravity = true;
                step++;
            }
        }*/
	}
}
