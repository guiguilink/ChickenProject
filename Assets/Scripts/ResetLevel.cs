using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {

	public int level;
	public float timeBeforeReset;
	public GameObject player;
	bool failure;
	float timer;

	// Use this for initialization
	void Start () 
	{
		failure = false;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (failure) 
		{
			timer += Time.deltaTime;

			if(timer > timeBeforeReset)
			{
				Application.LoadLevel("Level" + level);
				failure = false;
			}
		}
	}

	public void OnCollisionEnter (Collision c)
	{
		failure = true;
		player.rigidbody.Sleep();
	}
}
