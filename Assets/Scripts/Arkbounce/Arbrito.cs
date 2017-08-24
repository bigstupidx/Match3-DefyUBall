using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbrito : MonoBehaviour {


	private GameObject cardV;
	private GameObject card;
	private GameObject cardC;
	private GameObject cardR;
	private GameObject cardCR;

	private GameObject player;
	private float force = 50.0f;

	private GameObject spot1;
	private GameObject spot2;
	private GameObject spot3;


	private bool gospot1;
	private bool gospot2;
	private bool gospot3;



	private float next;
	private float wait;

	private float next2;
	private float wait2;

	public float timer;
	private float time2;

	private int counter;
	private bool startTime2 = false;
	// Use this for initialization
	void Start () {

		cardV = (GameObject)GameObject.FindGameObjectWithTag ("cardVoid");
		card = (GameObject)GameObject.FindGameObjectWithTag ("yellow");
		cardR = (GameObject)GameObject.FindGameObjectWithTag ("red");

		player = (GameObject)GameObject.FindGameObjectWithTag ("Player");

		spot1 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot1");
		spot2 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot2");
		spot3 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot3");

		wait = 3.0f;
		wait2 = 5.0f;
		}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.arbrito) {
			timer += Time.deltaTime;

			if (timer >= 12.0f) {
				gospot1 = true;
			}
			if (timer >= 15.0f)
				shootCardY ();

			if (timer >= 20.0f)
				shootCardR ();

			if (counter == 1) {
				gospot2 = true;
				gospot1 = false;
			} else if (counter == 2) {
				gospot3 = true;
				gospot2 = false;
				startTime2 = true;
				counter = 0;
			} 
			if (time2 >= 15.0f) {
				gospot3 = false;
				gospot1 = true;
				time2 = 0.0f;
				startTime2 = false;
			}

			if (startTime2)
				time2 += Time.deltaTime;
		
			movePos ();
		}
		if (!GameManager.arbrito)
			gospot3 = true;
	}

	void shootCardY()
	{
		if (GameManager.arbrito) {
			if (Time.time > next) {
				cardC = (GameObject)Instantiate (card, cardV.transform.position, card.transform.rotation);
				cardC.gameObject.GetComponent<Rigidbody> ().velocity = cardV.transform.forward * force;
				next = Time.time + wait;
			}
		}
	}

	void shootCardR()
	{
		if (GameManager.arbrito) {
			if (Time.time > next2) {
				cardCR = (GameObject)Instantiate (cardR, cardV.transform.position, cardR.transform.rotation);
				cardCR.gameObject.GetComponent<Rigidbody> ().velocity = cardV.transform.forward * force;
				next2 = Time.time + wait2;
			}
		}
	}
	void movePos()
	{
			if (gospot1)
				this.transform.position = new Vector2 (spot1.transform.position.x, spot1.transform.position.y);	
			if (gospot2)
				this.transform.position = new Vector2 (spot2.transform.position.x, spot2.transform.position.y);	
			if (gospot3)
				this.transform.position = new Vector2 (spot3.transform.position.x, spot3.transform.position.y);	
		
	}

	void countPos()
	{
		counter++;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ball") 
		{
			countPos ();
		}
	}
}
