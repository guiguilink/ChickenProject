using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {

	public int level;
	public float timeBeforeReset;
	public GameObject player;
	public GameObject camera;
	bool startSink;
	float timer;

	// Use this for initialization
	void Start () 
	{
		startSink = false;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startSink) 
		{
			Vector3 playerPosition = player.transform.position;
			timer += Time.deltaTime;
			player.transform.position = Vector3.Lerp(playerPosition, new Vector3(playerPosition.x, playerPosition.y - 10, playerPosition.z), .5f);

			if(timer > timeBeforeReset)
			{
				Application.LoadLevel("Level" + level);
				startSink = false;
			}
		}
	}

	public void OnCollisionEnter (Collision c)
	{
		startSink = true;
		player.rigidbody.Sleep();
		camera.GetComponent<CameraManager> ().SetGameOver (true);
	}

	public bool IsStartSink()
	{
		return startSink;
	}
}
