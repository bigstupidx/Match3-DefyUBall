using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArk : MonoBehaviour {


	private bool cantgoR = false;
	private bool cantgoL = false;

	private bool canshoot = true;
	private bool canCatch = false;
	private bool canMove = false;
	private bool takeBall = false;
	//private bool firstTouch = false;

	public static bool FirstShot = true;

	public int force;

	public float speed;

	private GameObject ball;
	private GameObject arrow;
	private GameObject copy;
	private GameObject player;

	private float playerx;
	//private GameObject reference;

	// Use this for initialization
	void Start () {

		ball = (GameObject)GameObject.FindGameObjectWithTag ("Ball");
		arrow = (GameObject)GameObject.FindGameObjectWithTag ("arrow");

		player = (GameObject)GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		
		PlayerMovementKeyboard (speed);
		PlayerMovementTouch (speed);

		shootBall(force);
		Catch ();

		/*if (Input.GetMouseButtonDown (1))
		{		
			canCatch = true;				

		}
		/*if (Input.touchCount == 1) 
		{
			firstTouch = true;
		}*/


	}

	void PlayerMovementKeyboard(float speed)
	{
		//GoRight
		if (!cantgoR) {
			if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
		}
		//GoRight
		if (!cantgoL) {
			if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))) {
				transform.Translate (Vector2.left * speed * Time.deltaTime);
			}
		}
	}
	void PlayerMovementTouch(float speed)
	{
		if (Input.touchCount > 0) {
			if (canMove == false) {
				if (!cantgoL) {
					if (Input.GetTouch (0).position.x < Screen.width / 2) {
						transform.Translate (Vector2.left * speed * Time.deltaTime);
					}
				}
				if (!cantgoR) {
					if (Input.GetTouch (0).position.x > Screen.width / 2) {
						transform.Translate (Vector2.right * speed * Time.deltaTime);
					}
				}
			}
		}
	}

	public void shootBall(float force)
	{
		if (FirstShot == true)
		{
			ball.transform.position = new Vector2 (this.transform.position.x, arrow.transform.position.y);
			//make arrow follow player
			arrow.gameObject.transform.position = new Vector2 (this.transform.position.x, arrow.transform.position.y);
		}
		if (canshoot)
		{
			if (Input.GetMouseButtonUp (0) ) {
				FirstShot = false;
				ball.gameObject.GetComponent<Rigidbody> ().velocity = arrow.transform.up * force;
				canshoot = false;
				arrow.SetActive (false);
				takeBall = false;
				canCatch = false;
				canMove = true;
			}

		}

	}

	public void Catch()
	{
		if (takeBall  && canCatch )
		{
			arrow.SetActive (true);
			FirstShot = true;	
			canshoot = true;
		}
				
	}



	//Collisions
	void OnCollisionEnter(Collision other)
	{
		//Players limits
		if (other.gameObject.tag == "limitL")
		{
			cantgoL = true;
		}
		if (other.gameObject.tag == "limitR")
		{
			cantgoR = true;
		}	
		if (other.gameObject.tag == "Ball")
		{
			if (canCatch)
			{
				takeBall = true;
			}
		}
	}
	void OnCollisionExit(Collision other)
	{
		//Player Limits
		if (other.gameObject.tag == "limitL")
		{
			cantgoL = false;
		}
		if (other.gameObject.tag == "limitR")
		{
			cantgoR = false;
		}

	}


}
