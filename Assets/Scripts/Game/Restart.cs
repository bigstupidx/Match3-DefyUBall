using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		GameLogic.Points = 0;
		GameLogic.GameOver = false;
		Application.LoadLevel (1);
	}
}
