using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static float speed;

	private bool cantgoR = false;
	private bool cantgoL = false;

	private float dtime;

	private GameObject hit;

	// Use this for initialization
	void Start () {
		
		//hit = (GameObject)GameObject.FindGameObjectWithTag ("hit");
		//hit.gameObject.SetActive (false);

		dtime = 0.3f;
		
	}

	// Update is called once per frame
	void Update () {

		//hit yellow
		if (GameLogic.Stun == true) 
		{
			//hit.gameObject.SetActive (true);
			dtime -= Time.deltaTime;
			speed = 1.0f;
			if (dtime < 0) 
			{
				GameLogic.Stun = false;
				speed = 100.0f;
				dtime = 0.3f;
			}
		}

		if(cantgoR == false){
				if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) 
		{
			this.gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
		}
		if (cantgoL == false) {
			if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))) {
				this.gameObject.transform.Translate (Vector2.left * speed * Time.deltaTime);
			}
		}
		if ((GameLogic.moreSpeed ==true) &&(GameLogic.GameOver == false)) {
			speed = 130.0f;
		} else if((GameLogic.moreSpeed == false)&&(GameLogic.GameOver == false)) {
			speed = 100.0f;
		}
	}

	void FixedUpdate ()
	{
		if (Input.touchCount > 0) {
			if (cantgoL == false) {
				if (Input.GetTouch (0).position.x < Screen.width / 2) {
					this.gameObject.transform.Translate (Vector2.left * speed * Time.deltaTime);
				}
			}
			if (cantgoR == false) {
				if (Input.GetTouch (0).position.x > Screen.width / 2) {
					this.gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);
				}
			}
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "limitL")
		{
			cantgoL = true;
		}
		if (collision.gameObject.tag == "limitR")
		{
			cantgoR = true;
		}
	}

	void OnCollisionExit(Collision collision)
	{

		if (collision.gameObject.tag == "limitL")
		{
			cantgoL = false;
		}
		if (collision.gameObject.tag == "limitR")
		{
			cantgoR = false;
		}

	}

}
