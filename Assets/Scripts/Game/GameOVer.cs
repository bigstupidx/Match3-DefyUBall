using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOVer : MonoBehaviour {

	private GameObject menu;
	private GameObject restart;
	// Use this for initialization
	void Start () {
		
		restart = (GameObject)GameObject.FindGameObjectWithTag ("Replay");
		menu = (GameObject)GameObject.FindGameObjectWithTag ("Menub");

		menu.gameObject.SetActive (false);
		restart.gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLogic.GameOver == true) {
			
			menu.gameObject.SetActive (true);
			restart.gameObject.SetActive (true);


			if (Input.GetMouseButtonDown (0)) {
				GameLogic.Points = 0;
				GameLogic.GameOver = false;
				Application.LoadLevel (1);
			}
			else if (Input.touchCount > 0) {
				GameLogic.Points = 0;
				GameLogic.GameOver = false;
				Application.LoadLevel (1);
			}
		}
	}
}
