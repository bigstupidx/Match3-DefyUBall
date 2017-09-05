using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	private GameObject formation1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnMouseDown ()
	{
		PlayerArk.FirstShot = true;
		GoalKeeper.speedkeeper = 17.0f;
		GameManager.arbrito = true;
		GameManager.oldScore = 0;
		GameManager.currentLevel++;
		Input.ResetInputAxes ();
		//GameManager.Instance.StartGame ();
		GameManager.Instance.nextFormation ();
	}
}