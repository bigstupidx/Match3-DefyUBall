using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArk : MonoBehaviour {

	public float bounciness;

	private bool hit = false;
	private bool wallhitL = false;

	public GameObject menu;
	public GameObject restart;

	private GameObject pjx;
	private GameObject porteria;

	private float playerx;
	private float currentpos;

	private bool wini=false;



	public float angularForce;
	// Use this for initialization
	void Start () {

		pjx = (GameObject)GameObject.FindGameObjectWithTag ("Player");
		playerx = pjx.gameObject.transform.position.x;

		porteria = (GameObject)GameObject.FindGameObjectWithTag ("porteria");

		/*menu = (GameObject)GameObject.FindGameObjectWithTag ("Menub");
		restart = (GameObject)GameObject.FindGameObjectWithTag ("Replay");*/

		//menu.gameObject.SetActive (true);
		restart.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
		currentpos = transform.position.x;

		if (wini)
		{
			gameObject.transform.transform.position = new Vector2 (transform.position.x, porteria.transform.position.y);
		}

	}


	public void bounce(float bounciness, float angularForce)
	{
		
			if (currentpos > playerx) {
				gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (angularForce * bounciness, 0));
			
			} if (currentpos < playerx) {
				gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector2 (-angularForce * bounciness, 0));
			}		
	}

	public void GameEnd()
	{
		restart.gameObject.SetActive (true);
		gameObject.GetComponent<Rigidbody>().drag = 3.2f;
		gameObject.GetComponent<Rigidbody>().angularDrag = 0.0f;
	}
	public void GameWin()
	{
		restart.gameObject.SetActive (true);
		gameObject.GetComponent<Rigidbody>().drag = 3.2f;
		gameObject.GetComponent<Rigidbody>().angularDrag = 0.0f;

	}
	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Respawn") 
		{
			
			bounce (bounciness, angularForce);
		}

		if (other.gameObject.tag == "cube") 
		{
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "GameOver")
		{
			GameEnd ();
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "porteria")
		{
			GameWin ();
			wini = true;
		}
	}



}
