using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMEnu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		GameLogic.GameOver = false;
		GameLogic.Points = 0;
		Application.LoadLevel (0);


	}
}
