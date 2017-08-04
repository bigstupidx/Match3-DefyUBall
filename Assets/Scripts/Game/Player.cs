using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static float speed;
	// Use this for initialization
	void Start () {
		speed = 30.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) 
		{
			this.gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);
		}

		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))) 
		{
			this.gameObject.transform.Translate (Vector2.left * speed * Time.deltaTime);
		}
		
	}

	void FixedUpdate ()
	{
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).position.x < Screen.width / 2)
			{
				this.gameObject.transform.Translate (Vector2.left * speed * Time.deltaTime);
			}
			if (Input.GetTouch (0).position.x > Screen.width / 2)
			{
				this.gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
		}
	}


}
