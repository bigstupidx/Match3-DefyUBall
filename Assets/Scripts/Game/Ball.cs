using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {


	//Variable Rebote(bounce)
	public float bounce;
	private float bounce2;

	private float wbounce;
	private float wbounce2;

	//variable Collision
	public static bool onTouch = false;
	public static bool firstTouch = false;
	public static bool canRotate = false;
	// Use this for initialization

	private float next;
	private float next1;
	private float espera;

	private float playerx;
	private GameObject pjx;
	private float currentpos;

	private Rigidbody rigidbody;
	void Start () {
		//Bounce Force
		bounce = 5000.0f;
		bounce2 = 1500.0f;

		wbounce = 1600.0f;



		espera = 0.5f;
		pjx = (GameObject)GameObject.FindGameObjectWithTag ("Player");

		playerx = pjx.gameObject.transform.position.x;

		rigidbody = GetComponent<Rigidbody>();
		}

	
	// Update is called once per frame
	void Update () {

		currentpos = this.gameObject.transform.position.x;
		//Random Direction bounce2
		wbounce2 = Random.Range (-800,800);

		//Debug.Log (onTouch);
		Debug.Log (bounce);

	

		//if==true add force
		if (onTouch == true) {
			return;
			//rigidbody.velocity = rigidbody.velocity.normalized * bounce;
			if (Time.time > next) {
				if (this.gameObject.transform.position.x >= pjx.gameObject.transform.position.x) {
					
					this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector2 (bounce2, bounce));

				}

				if (this.gameObject.transform.position.x < pjx.gameObject.transform.position.x) {
					this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector2 (-bounce2, bounce));

				}
				next = Time.time + espera;
			}
			/*if (this.gameObject.transform.position.x == pjx.gameObject.transform.position.x) {
					this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (bounce / 2, bounce / 2));
				}*/
			
		}
	
		
	}

	//function Rebote
	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Player") {
			firstTouch = true;
			canRotate = true;
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
			this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (wbounce +wbounce2, 0.0f));
		}
		if (collision.gameObject.tag == "limitR") 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (-wbounce-wbounce2, 0.0f));
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
			canRotate = false;
		}

	}
}
