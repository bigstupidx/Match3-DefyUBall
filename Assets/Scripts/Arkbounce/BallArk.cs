using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArk : MonoBehaviour {
	
	public float bounciness;
	private bool bounceR = false;
	private bool bounceL = false;

	public GameObject menu;
	public GameObject restart;
	public GameObject nextL;

	private GameObject pjx;
	private GameObject porteria;

	private float playerx;
	private float currentpos;
	private float currentposy;
	private float returnPos;

	public bool wini=false;




	private GameObject x2boost;
	private GameObject x2Void;
	private float x2life;
	private GameObject copy;
	private GameObject copy2;

	private float x2timer;

	private float x2counter;

	private GameObject particle;
	private float particlelife = 0.40f;
	private bool showPart = false;


	Vector3 lastPosition = Vector3.zero;
	public float speed;

	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {

		x2life = 1.0f;

		pjx = (GameObject)GameObject.FindGameObjectWithTag ("Player");


		porteria = (GameObject)GameObject.FindGameObjectWithTag ("porteria");

		x2boost = (GameObject)GameObject.FindGameObjectWithTag ("x2boost");
		x2Void = (GameObject)GameObject.FindGameObjectWithTag ("x2void");
		
		particle = (GameObject)GameObject.FindGameObjectWithTag ("Particle");

		particle.SetActive (false);

		restart.gameObject.SetActive (false);
		nextL.gameObject.SetActive (false);

		rigidbody = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{
		
		bounceDirection ();
		//constant speed
		rigidbody.velocity = rigidbody.velocity.normalized * speed;

	}

	// Update is called once per frame
	void Update () 
	{
		if (wini)
		{
			gameObject.transform.transform.position = new Vector2 (transform.position.x, porteria.transform.position.y);
		}

		showP ();

		currentpos = transform.position.x;
		currentposy = transform.position.y;
	}


	void bounceDirection()
	{
		
		playerx = pjx.gameObject.transform.position.x;
		if (currentpos > playerx) 
		{
			bounceR = true;
			bounceL = false;
		}
			
			 if (currentpos < playerx) 
		{
			bounceR = false;
			bounceL = true;
		}
				

	}


	public void GameEnd()
	{		
		gameObject.GetComponent<Rigidbody>().drag = 3.2f;
		gameObject.GetComponent<Rigidbody>().angularDrag = 3.0f;
		GoalKeeper.speedkeeper = 0.0f;
		GameManager.arbrito = false;
		speed = 0.0f;
	}
	public void GameWin()
	{
		restart.gameObject.SetActive (true);
		nextL.gameObject.SetActive (true);
		gameObject.GetComponent<Rigidbody>().drag = 3.2f;
		gameObject.GetComponent<Rigidbody>().angularDrag = 3.0f;
		GoalKeeper.speedkeeper = 0.0f;
		GameManager.arbrito = false;
		speed = 0.0f;

	}
	void ShowX2()
	{
		copy = (GameObject)Instantiate (x2boost, x2Void.transform.position, x2boost.transform.rotation);

		Destroy (copy.gameObject, x2life);
	}
	void showP()
	{
		if (showPart) 
		{
			particle.SetActive(true);

			particlelife -=Time.deltaTime;

			if (particlelife < 0.0f) {
				particle.SetActive (false);
				showPart = false;
				particlelife = 0.40f;
			}
		}

	}

	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Respawn") 
		{
			var bouncinessX = Mathf.Abs (playerx - transform.position.x) * 8;
			if(bounceL)
				rigidbody.velocity = new Vector3 (-bouncinessX, bounciness,0);
			if(bounceR)
				rigidbody.velocity = new Vector3 (bouncinessX, bounciness,0);
			
			x2counter = 0.0f;
		
		}
		if (other.gameObject.tag == "limitL" || other.gameObject.tag == "limitR"|| other.gameObject.tag =="Palo") 
		{			
			rigidbody.velocity = new Vector3 (other.relativeVelocity.x, -other.relativeVelocity.y);
			x2counter = 0.0f;

		}
		if (other.gameObject.tag == "limitT") 
		{
			x2counter = 0.0f;
			rigidbody.velocity = new Vector3 (-other.relativeVelocity.x, other.relativeVelocity.y);
		
		}
		if (other.gameObject.tag == "cube") 
		{
			x2counter++;
			GameManager.oldScore++;
			Destroy (other.gameObject);
		
			GameManager.Instance.sumPoints();
			if (x2counter > 1)
			{
				ShowX2 ();
				GameManager.Instance.sumPoints();
				GameManager.oldScore++;
			}
			showPart = true;

			particle.gameObject.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, particle.transform.position.z);
		}
		if (other.gameObject.tag == "GameOver")
		{
			//GameEnd ();
			GameManager.arbrito = false;
			GameManager.Instance.GameEnd();
			x2counter = 0.0f;
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "porteria")
		{
			GameManager.arbrito = false;
			GameWin ();
			wini = true;
			x2counter = 0.0f;
		}
	}



}
