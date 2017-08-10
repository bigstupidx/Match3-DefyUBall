using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	//Gravedad
	public Vector3 Gravity;
	public float gravy;

	public static int Points = 0;
	public static int currentPoints=0;

	public static bool DoubleP = false;
	public static bool moreSpeed = false;
	public static bool makeClone = false;
	public static bool makeBig = false;
	public static bool showBig = false;

	public static bool isAbove = false;

	public static bool slowMo = false;
	public static bool showWatch = false;
	public static bool stopShowWatch = false;
	private GameObject dark;
	private GameObject watch;
	private GameObject ball;
	private float timer;
	private float timer2;

	public static bool Stun = false;

	public static bool GameOver = false;

	public static int pSkinBall = 0;
	public static int pSkinPlayer = 0;

	private GameObject lights;



	//public GameObject PointsText;
	//public Text PointsText;

	// Use this for initialization
	void Start () {
		//Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);



		gravy = -200.0f;


		lights = (GameObject)GameObject.FindGameObjectWithTag ("Lights");
		lights.gameObject.SetActive (false);

		dark = (GameObject)GameObject.FindGameObjectWithTag ("dark");
		watch = (GameObject)GameObject.FindGameObjectWithTag ("watch");
		ball = (GameObject)GameObject.FindGameObjectWithTag ("Ball");
		
	}

	// Update is called once per frame
	void Update () {
	
		//Gravedad
		Physics.gravity = new Vector3 (0.0f, gravy, 0.0f);


		//Debug.Log (Time.deltaTime.ToString("N0"));
		if (Points > 1)
		{
			lights.gameObject.SetActive (true);
		}

		if (Points == 18)
		{
			showWatch = true;
		}
		if (stopShowWatch == true) 
		{
			timer2 += Time.deltaTime;
			if (timer2 > 16)
			{
				showWatch = true;
				stopShowWatch = false;
			}
		}


		if (slowMo == true) 
		{
			timer += Time.deltaTime;
			dark.gameObject.SetActive (true);
			showWatch = false;
			ball.gameObject.GetComponent<Rigidbody>().mass =1.0f;
			ball.gameObject.GetComponent<Rigidbody>().drag = 3.2f;
			ball.gameObject.GetComponent<Rigidbody>().angularDrag = 0.0f;
			ball.gameObject.GetComponent<Rigidbody>().useGravity = false;
			ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			if (timer > 4)
			{
				dark.gameObject.SetActive (false);
			}
			if (timer > 5)
			{
				slowMo = false;
			}
		

		}
		if (slowMo == false) 
		{
			dark.gameObject.SetActive (false);
			ball.gameObject.GetComponent<Rigidbody>().mass = 0.8f;
			ball.gameObject.GetComponent<Rigidbody>().drag = 0.01f;
			ball.gameObject.GetComponent<Rigidbody>().angularDrag = 0.05f;
			ball.gameObject.GetComponent<Rigidbody>().useGravity = true;

		}

		if (showWatch == false)
		{
			watch.gameObject.SetActive (false);
		}
		if (showWatch == true)
		{
			watch.gameObject.SetActive (true);
		}
	}


}
