using UnityEngine;
using System.Collections;

public class MoveScene : MonoBehaviour {

	public int maxXAngle;
	public int maxYAngle;
	public float moveVelocity;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.anyKey) 
		{
			if (Input.GetButton ("Up") && transform.rotation.x < (maxXAngle / 360f))
				transform.rotation *= Quaternion.Euler (Mathf.Abs (Input.GetAxis ("Vertical")) * moveVelocity, 0, 0);
			else if (Input.GetButton ("Down") && transform.rotation.x > (-maxXAngle / 360f))
				transform.rotation *= Quaternion.Euler (-Mathf.Abs (Input.GetAxis ("Vertical")) * moveVelocity, 0, 0);

			if (Input.GetButton ("Left") && transform.rotation.z < (maxXAngle / 360f))
				transform.rotation *= Quaternion.Euler (0, 0, Mathf.Abs (Input.GetAxis ("Horizontal")) * moveVelocity);
			else if (Input.GetButton ("Right") && transform.rotation.z > (-maxXAngle / 360f))
				transform.rotation *= Quaternion.Euler (0, 0, -Mathf.Abs (Input.GetAxis ("Horizontal")) * moveVelocity);
		}
	}
}
