using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerArk : MonoBehaviour
{

    public GameObject PowerUPP;
    private GameObject showPowerEffect;
	private bool cantgoR = false;
	private bool cantgoL = false;

	public static  bool canshoot = true;
	private bool canCatch = false;
	public bool canMove = false;
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

	//private int score;

	private float timer;

	private bool hitY = false;

	private float MinSpeed = 25.0f;
	private float MaxSpeed = 200.0f;
	private float TimeToMaxSpeed = 0.8f;
	private float _timeTouch;

	private float _timeTouchT;

	private bool showArrows = false;

	private float ModSpeed{ get { return Mathf.Lerp (MinSpeed, MaxSpeed, _timeTouch / TimeToMaxSpeed); } }

	private float ModSpeedT{ get { return Mathf.Lerp (MinSpeed, MaxSpeed, _timeTouchT / TimeToMaxSpeed); } }


	private GameObject lR;
	private GameObject lF;




	// Use this for initialization
	void Start ()
	{
		ball = (GameObject)GameObject.FindGameObjectWithTag ("Ball");
		arrow = (GameObject)GameObject.FindGameObjectWithTag ("arrow");
		player = (GameObject)GameObject.FindGameObjectWithTag ("Player");
		lR = (GameObject)GameObject.FindGameObjectWithTag ("limitR");
		lF = (GameObject)GameObject.FindGameObjectWithTag ("limitL");

	}

	// Update is called once per frame
	void Update ()
	{
		PlayerMovementKeyboard (speed);
		PlayerMovementTouch (speed);
		shootBall (force);
		Catch ();



/*if (Input.GetMouseButtonDown (1))
{		
canCatch = true;				

}*/
		if (GameManagerArk.Instance.isMenu) {

			if (Input.GetMouseButtonDown (0)) {

                GameManagerArk.Instance.isMenu = false;
			}
		}
	}

	void PlayerMovementKeyboard (float speed)
	{
		if (!GameManagerArk.Instance.isMenu) {
			if (canMove) {
				StopGoinSides ();
				bool moving = false;
//GoRight
				if (!cantgoR) {
					if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
						transform.Translate (Vector2.right * ModSpeed * Time.deltaTime);
						_timeTouch += Time.deltaTime;
						moving = true;
					} 
				}
//GoRight
				if (!cantgoL) {
					if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))) {
						transform.Translate (Vector2.left * ModSpeed * Time.deltaTime);
						_timeTouch += Time.deltaTime;
						moving = true;
					}
				}
				if (!moving)
					_timeTouch = 0.0f;
			}
		}
	}

	void PlayerMovementTouch (float speed)
	{
		if (!GameManagerArk.Instance.isMenu) {
			if (canMove) {
				if (Input.touchCount > 0) {

					StopGoinSides ();
					bool movingT = false;

					if (FirstShot == false) {
						if (!cantgoL) {
							if (Input.GetTouch (0).position.x/*Input.mousePosition.x*/ < Screen.width / 2) {
								transform.Translate (Vector2.left * ModSpeedT * Time.deltaTime);
								_timeTouchT += Time.deltaTime;
								movingT = true;
							}
						}
						if (!cantgoR) {
							if (Input.GetTouch (0).position.x/*Input.mousePosition.x*/ > Screen.width / 2) {
								transform.Translate (Vector2.right * ModSpeedT * Time.deltaTime);
								_timeTouchT += Time.deltaTime;
								movingT = true;


							}
						}
						if (!movingT || Input.GetMouseButtonUp (0))
							_timeTouchT = 0.0f;
					}




				}
			}
		}
	}

	public void shootBall (float force)
	{
		if (FirstShot == true) {
            canMove = false;
			arrow.SetActive (true);
			ball.transform.position = new Vector2 (this.transform.position.x, arrow.transform.position.y);
//make arrow follow player
			arrow.gameObject.transform.position = new Vector2 (this.transform.position.x, arrow.transform.position.y);
		}

		if (canshoot) {
			if (!GameManagerArk.Instance.isMenu) {

				if (Input.GetMouseButton (0)) {					
					FirstShot = false;
					GameManagerArk.Instance.showArs = true;
					ball.gameObject.GetComponent<Rigidbody> ().velocity = arrow.transform.up * force;
					arrow.SetActive (false);
					takeBall = false;
					canCatch = false;
					canMove = true;
					canshoot = false;
				}

			}
		}


	}

	public void Catch ()
	{
		if (takeBall && canCatch) {
			arrow.SetActive (true);
			FirstShot = true;	
			canshoot = true;
		}

	}

	void hiByYellow ()
	{
		hitY = true;
	}

	void hitByRed ()
	{
        GameManagerArk.Instance.GameEnd ();
	}

	void StopGoinSides ()
	{

		if (gameObject.transform.position.x < lF.transform.position.x + 4.0f)
			cantgoL = true;
		else
			cantgoL = false;


		if (gameObject.transform.position.x > lR.transform.position.x - 4.0f)
			cantgoR = true;
		else
			cantgoR = false;

	}


	//Collisions
	void OnCollisionEnter (Collision other)
	{

		if (other.gameObject.tag == "Ball") {
			if (canCatch) {
				takeBall = true;
			}
		}
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "yellow") {
			hiByYellow ();
			Arbrito.ShootRed = true;
		}
		if (other.gameObject.tag == "red") {
			hitByRed ();
		}
		if (other.gameObject.tag == "hand") {
            showPowerEffect = (GameObject)Instantiate(PowerUPP, other.transform.position, other.transform.rotation);
            canCatch = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "DoublePoints") {
            showPowerEffect = (GameObject)Instantiate(PowerUPP, other.transform.position, other.transform.rotation);
            GameManagerArk.Instance.x2Boost = true;
			Destroy (other.gameObject);
		}


	}


}
