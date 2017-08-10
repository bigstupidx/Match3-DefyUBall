using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTimer : MonoBehaviour {

	private float timeLeft;


	// Use this for initialization
	void Start () 
	{
		
		timeLeft = 5.0f;

	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (timeLeft);

		if(GameLogic.moreSpeed == true)
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) 
			{
				GameLogic.moreSpeed = false;
				timeLeft = 5.0f;
			}
		}

	}
}
