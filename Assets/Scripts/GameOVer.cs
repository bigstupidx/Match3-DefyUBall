using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOVer : MonoBehaviour {


	private Text restart;
	// Use this for initialization
	void Start () {
		restart = GetComponent<Text>();
		restart.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLogic.GameOver == true) {
			restart.text = "TAP TO CONTINUE";

			if (Input.GetMouseButtonDown (0)) {
				GameLogic.Points = 0;
				GameLogic.GameOver = false;
				Application.LoadLevel (0);
			}
			else if (Input.touchCount > 0) {
				GameLogic.Points = 0;
				GameLogic.GameOver = false;
				Application.LoadLevel (0);
			}
		}
	}
}
