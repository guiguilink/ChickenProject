using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public GameObject player;
	public float delayCameraUpdate;
    Vector3 playerOffset;
	float timer;
	bool gameOver;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerOffset = transform.position - player.transform.position;
		gameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!gameOver) 
		{
			timer += Time.deltaTime;

            //if (timer > delayCameraUpdate) 
            //{
            //    transform.LookAt (player.transform);
            //    iTween.MoveUpdate(gameObject, player.transform.position + playerOffset, 1f);
            //    timer = 0f;
            //}
			//iTween.MoveUpdate(gameObject, player.transform.position + playerOffset, 1f);
			//Debug.Log (transform.position.sqrMagnitude.ToString () + " | " + player.transform.position.sqrMagnitude.ToString ());
		}
	}

	public void SetGameOver(bool isGameOver)
	{
		gameOver = isGameOver;
	}
}
