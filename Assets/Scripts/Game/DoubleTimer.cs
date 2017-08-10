using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleTimer : MonoBehaviour {

	private float timeLeft;

	private GameObject showx2;

	// Use this for initialization
	void Start () 
	{
		timeLeft = 5.0f;
		showx2 =  (GameObject)GameObject.FindGameObjectWithTag ("x2Show");
		showx2.gameObject.SetActive (false);
		
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (timeLeft);

		if(GameLogic.DoubleP == true)
		{
		timeLeft -= Time.deltaTime;
			showx2.gameObject.SetActive (true);
			if (timeLeft < 0) 
			{
				GameLogic.DoubleP = false;
				timeLeft = 5.0f;
				showx2.gameObject.SetActive (false);
			}
		}
		
	}
}
