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

	public static bool GameOver = false;

	//public GameObject PointsText;
	//public Text PointsText;

	// Use this for initialization
	void Start () {
		gravy = -15.0f;
		//PointsText = GetComponent<Text>();
		//PointsText.text = "hola";
		
	}
	
	// Update is called once per frame
	void Update () {



		//Gravedad
		Physics.gravity = new Vector3 (0.0f, gravy, 0.0f);

		//text points
		//PointsText.text = Points.ToString();
	}


}
