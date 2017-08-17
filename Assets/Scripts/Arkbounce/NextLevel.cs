using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		PlayerArk.FirstShot = true;
		GoalKeeper.speedkeeper = 17.0f;
		//Application.LoadLevel (3);
	}
}
