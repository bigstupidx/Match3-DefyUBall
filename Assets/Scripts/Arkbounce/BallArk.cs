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

	private GameObject lR;
	private GameObject lF;

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

	public GameObject particle;
	private GameObject cparticle;
	private float particlelife = 0.40f;
	private float particlelife2 = 0.40f;
	private bool showPart = false;

    public GameObject hitPlayer;
    private GameObject showHitPlayer;


	Vector3 lastPosition = Vector3.zero;
	public float speed;

	private ShowSum showsum;

	private Rigidbody rigidbody;
	private bool x2 =false;

	public GameObject GrabBall;
	private GameObject copyGrab;

	public GameObject coin;
	private GameObject copyCoin;


	public GameObject Goal;
	private ShowGoal showgoal;
	public GameObject cGoal;
	private bool bGoal = false;
	// Use this for initialization
	void Start () {
		

		x2life = 1.0f;

		pjx = (GameObject)GameObject.FindGameObjectWithTag ("Player");


		porteria = (GameObject)GameObject.FindGameObjectWithTag ("porteria");
		lR= (GameObject)GameObject.FindGameObjectWithTag ("limitR");
		lF = (GameObject)GameObject.FindGameObjectWithTag ("limitL");

		x2boost = (GameObject)GameObject.FindGameObjectWithTag ("x2boost");
		x2Void = (GameObject)GameObject.FindGameObjectWithTag ("x2void");
		
	

		restart.gameObject.SetActive (false);
		nextL.gameObject.SetActive (false);

		rigidbody = GetComponent<Rigidbody>();

		showsum = FindObjectOfType<ShowSum>();

		showgoal = FindObjectOfType<ShowGoal> ();

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
			//gameObject.transform.transform.position = new Vector2 (transform.position.x, porteria.transform.position.y);
		}
		if(showPart)
			ShowSumx1 ();


		currentpos = transform.position.x;
		currentposy = transform.position.y;

		putBallBack ();

		if (x2)
		{
			showsum.showPlus (2);
			particlelife2 -= Time.deltaTime;
			if (particlelife2 < 0.0f) {
				showsum.showPlus (0);
				particlelife2 = 0.40f;
				x2 = false;
			}
		}
		if (bGoal) 
		{
			if (cGoal == null) {
				cGoal = (GameObject)Instantiate (Goal, Goal.transform.position, Goal.transform.rotation);
				//cGoal.GetComponent<ShowGoal> ().PlayGoalUI ();
				bGoal = false;
			}
		}
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
		gameObject.GetComponent<Rigidbody>().drag = 1000.0f;
		gameObject.GetComponent<Rigidbody>().angularDrag = 1000.0f;
		GoalKeeper.speedkeeper = 0.0f;
        GameManagerArk.arbrito = false;
		Destroy (copyCoin);
		Destroy (copyGrab);

		speed = 0.0f;
	}
	public void GameWin()
	{
		bGoal = true;

		//restart.gameObject.SetActive (true);
		nextL.gameObject.SetActive (true);
		gameObject.GetComponent<Rigidbody>().drag = 1000.0f;	
		gameObject.GetComponent<Rigidbody>().angularDrag = 1000.0f;
		GoalKeeper.speedkeeper = 0.0f;
        GameManagerArk.arbrito = false;
		speed = 0.0f;
		Destroy (copyCoin);
		Destroy (copyGrab);
		showsum.showPlus(10);
        GameManagerArk.Instance.sumGoal ();


	}
	void ShowX2()
	{
		
			copy = (GameObject)Instantiate (x2boost, x2Void.transform.position, x2boost.transform.rotation);
			
			Destroy (copy.gameObject, x2life);



	}
	void ShowSumx1()
	{
		showsum.showPlus (1);
		particlelife -= Time.deltaTime;
		if (particlelife < 0.0f) {
			showsum.showPlus (0);
			particlelife = 0.40f;
			showPart = false;
		}
	}


	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Respawn") 
		{
			var bouncinessX = Mathf.Abs (playerx - transform.position.x) * 3;
			if(bounceL)
				rigidbody.velocity = new Vector3 (-bouncinessX, bounciness,0);
			if(bounceR)
				rigidbody.velocity = new Vector3 (bouncinessX, bounciness,0);
			
			x2counter = 0.0f;

            showHitPlayer = (GameObject)Instantiate(hitPlayer, other.transform.position, other.transform.rotation);

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
            GameManagerArk.oldScore++;
			Destroy (other.gameObject);
			showPart = true;
            GameManagerArk.Instance.sumPoints();
			if (GameManagerArk.Instance.x2Boost)
			{
				ShowX2 ();
				x2 = true;

                GameManagerArk.Instance.sumPoints();
                GameManagerArk.oldScore++;
			}
				
			cparticle = (GameObject)Instantiate (particle, other.transform.position, other.transform.rotation);
			Destroy (cparticle, 0.40f);

			//SpawnGrab 4%
			if (Random.value <= 0.03f) 
			{
				//if (copyCoin == null) {
					copyGrab = (GameObject)Instantiate (GrabBall, other.transform.position, other.transform.rotation);
					Destroy (copyGrab, 8.0f);
				//}

			}
			//SpawnCoin 6%
			if (Random.value <= 0.07f) 
			{
				//if (copyGrab == null) {
					copyCoin = (GameObject)Instantiate (coin, other.transform.position, other.transform.rotation);
					Destroy (copyCoin, 8.0f);
				//}

			}
		}
		if (other.gameObject.tag == "GameOver")
		{
            //GameEnd ();
            GameManagerArk.arbrito = false;
            GameManagerArk.Instance.GameEnd();
			x2counter = 0.0f;
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "porteria")
		{
            GameManagerArk.arbrito = false;
            GameManagerArk.Instance.advance = false;
			GameWin ();
			wini = true;
			x2counter = 0.0f;
		}
	}

	void putBallBack()
	{
		if (gameObject.transform.position.x < lF.transform.position.x) {
			
			PlayerArk.FirstShot = true;
			PlayerArk.canshoot = true;
		}
		if (gameObject.transform.position.x > lR.transform.position.x) {
			
			PlayerArk.FirstShot = true;
			PlayerArk.canshoot = true;
		}
	}



}
