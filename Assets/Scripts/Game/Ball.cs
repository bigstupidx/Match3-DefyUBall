using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {


	//Variable Rebote(bounce)
	public float bounce;
	private float bounce2;

	//variable Collision
	private bool onTouch = false;
	// Use this for initialization



	void Start () {
		//Bounce Force
		bounce = 2100.0f;


		}

	
	// Update is called once per frame
	void Update () {

		//Random Direction bounce2
		bounce2 = Random.Range (-800,800);

		//Debug.Log (onTouch);
		//Debug.Log (bounce2);

		//if==true add force
		if (onTouch == true) 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (bounce2, bounce));
		}
		
	}

	//function Rebote
	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Player") {
			if (GameLogic.DoubleP == false) {
				GameLogic.Points = GameLogic.Points + 1;
			} else if (GameLogic.DoubleP == true) {
				GameLogic.Points = GameLogic.Points + 2;
			}

			//Debug.Log ("touch");
			onTouch = true;
			}

		if (collision.gameObject.tag == "limitL") 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (1500.0f, 0.0f));
		}
		if (collision.gameObject.tag == "limitR") 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (-1500.0f, 0.0f));
		}

		if (collision.gameObject.tag == "GameOver") 
		{
			GameLogic.GameOver = true;
			Player.speed = 0.0f;
		}
	}
	void OnCollisionExit(Collision collision)
	{

		if (collision.gameObject.tag == "Player") {
			
			onTouch = false;
		}

	}
}
