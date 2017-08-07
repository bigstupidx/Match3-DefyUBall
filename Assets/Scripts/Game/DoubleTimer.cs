using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleTimer : MonoBehaviour {

	private float timeLeft;

	private Text timer;
	// Use this for initialization
	void Start () 
	{
		timer = GetComponent<Text>();
		timer.text = "";
		timeLeft = 5.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (timeLeft);

		if(GameLogic.DoubleP == true)
		{
		timeLeft -= Time.deltaTime;
			timer.text = "X2 Score: " + timeLeft.ToString ("N0");
			if (timeLeft < 0) 
			{
				GameLogic.DoubleP = false;
				timer.text = "";
				timeLeft = 5.0f;
			}
		}
		
	}
}
