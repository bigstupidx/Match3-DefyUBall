using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BMEnu : MonoBehaviour {
	
	private BallArk ball;
	private PlayerArk pspeed;
	private Arbrito arb;


	// Use this for initialization
	void Start () {
		
		ball = FindObjectOfType<BallArk>();
		pspeed = FindObjectOfType<PlayerArk>();
		arb = FindObjectOfType<Arbrito>();


		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{

		GameManager.oldScore = 0;

		pspeed.speed = 100.0f;
		pspeed.canshoot = true;
		ball.speed = 80.0f;
		arb.ResetEverything();
		ball.wini = false;
		GameManager.arbrito = true;

		GameLogic.GameOver = false;
		GameLogic.Points = 0;
		Application.LoadLevel (0);


	}
}
