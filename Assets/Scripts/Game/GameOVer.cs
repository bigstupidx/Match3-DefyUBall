using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOVer : MonoBehaviour {

	private GameObject menu;
	private Text restart;
	// Use this for initialization
	void Start () {
		restart = GetComponent<Text>();
		restart.text = "";

		menu = (GameObject)GameObject.FindGameObjectWithTag ("Menub");

		menu.gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLogic.GameOver == true) {
			restart.text = "TAP TO RESTART";
			menu.gameObject.SetActive (true);


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
