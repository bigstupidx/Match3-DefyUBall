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

	public static bool GameOver = false;

	public static int pSkinBall = 0;
	public static int pSkinPlayer = 0;

	private GameObject lights;

	//public GameObject PointsText;
	//public Text PointsText;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);

		gravy = -50.0f;
		//PointsText = GetComponent<Text>();
		//PointsText.text = "hola";

		lights = (GameObject)GameObject.FindGameObjectWithTag ("Lights");

		lights.gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {



		//Gravedad
		Physics.gravity = new Vector3 (0.0f, gravy, 0.0f);

		//text points
		//PointsText.text = Points.ToString();

		if (Points > 1)
		{
			lights.gameObject.SetActive (true);
		}
	}


}
