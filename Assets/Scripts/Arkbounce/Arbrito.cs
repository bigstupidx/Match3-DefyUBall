using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbrito : MonoBehaviour {


	private GameObject cardV;
	private GameObject card;
	public GameObject cardC;
	private GameObject cardR;
	public GameObject cardCR;

	private GameObject player;
	private float force = 50.0f;

	private GameObject spot1;
	private GameObject spot2;
	private GameObject spot3;


	private bool gospot1;
	private bool gospot2;
	public bool gospot3;



	private float next;
	public float wait;


	public float timer;
	private float time2;
	private float timerp;
	private float timerp2;

	private int counter;
	private bool startTime2 = false;

	public static bool ShootRed = false;
	// Use this for initialization
	void Start () {

		cardV = (GameObject)GameObject.FindGameObjectWithTag ("cardVoid");
		card = (GameObject)GameObject.FindGameObjectWithTag ("yellow");
		cardR = (GameObject)GameObject.FindGameObjectWithTag ("red");

		player = (GameObject)GameObject.FindGameObjectWithTag ("Player");

		spot1 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot1");
		spot2 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot2");
		spot3 = (GameObject)GameObject.FindGameObjectWithTag ("aSpot3");


		//wait2 = 5.0f;

		}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.arbrito + "arbrito");
		//Debug.Log ("spot1= " + gospot1);
		//Debug.Log ("timer= " + timer);
		/*Debug.Log ("spot2= " + gospot2);*/
		if (!PlayerArk.FirstShot) {
			if (GameManager.arbrito) {
				boolSets ();
				timer += Time.deltaTime;

				if (timer >= 2.0f && timer <= 2.1f) {
					gospot1 = true;

				}
				if (timer >= 10.0f)
					shootCardY ();

				if (ShootRed)
					shootCardR ();

				/*if (counter == 1) {
				gospot2 = true;
				gospot1 = false;
			} else if (counter == 2) {
				gospot3 = true;
				gospot2 = false;
				startTime2 = true;
				counter = 0;
			} */
				if (time2 >= 15.0f) {
					gospot3 = false;
					gospot1 = true;
					time2 = 0.0f;
					startTime2 = false;
				}

				if (startTime2)
					time2 += Time.deltaTime;
				if (gospot1) {
					timerp += Time.deltaTime;
					if (timerp >= 10.0f) {
						gospot1 = false;
						gospot2 = true;
						timerp = 0.0f;
					}
				}
				if (gospot2) {
					timerp2 += Time.deltaTime;
					if (timerp2 >= 10.0f) {
						gospot1 = true;
						timerp2 = 0.0f;
					}
				}
		
				movePos ();
			}
			if (GameManager.arbrito == false)
				ResetEverything ();
		}
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
			
				cardCR = (GameObject)Instantiate (cardR, cardV.transform.position, cardR.transform.rotation);
				cardCR.gameObject.GetComponent<Rigidbody> ().velocity = cardV.transform.forward * force;
				

			ShootRed = false;
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

	/*void countPos()
	{
		counter++;
	}
	void restPos()
	{
		counter--;
	}*/

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ball") 
		{
			ResetEverything ();
		}
	}

	void boolSets()
	{
		if (gospot1) 
		{
			gospot2 = false;
			gospot3 = false;
		}
		if (gospot2) 
		{
			gospot1 = false;
			gospot3 = false;
		}
		if (gospot3) 
		{
			gospot2 = false;
			gospot1 = false;
		}
	}
	public void ResetEverything()
	{

		gospot3 = true;
		gospot1 = false;
		gospot2 = false;
		timer = 0.0f;
		time2 = 0.0f;
		timerp = 0.0f;
		timerp2 = 0.0f;
		
	}
}
