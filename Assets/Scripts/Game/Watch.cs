using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		GameLogic.slowMo = true;
		GameLogic.showWatch = false;
		GameLogic.stopShowWatch = true;

	}
}
