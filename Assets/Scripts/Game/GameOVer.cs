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
			GameLogic.makeBig = false;
			GameLogic.showBig = false;
			GameLogic.showWatch = false;
			GameLogic.DoubleP = false;
			GameLogic.moreSpeed = false;
			GameLogic.makeClone = false;
			GameLogic.slowMo = false;
			GameLogic.stopShowWatch = false;


		}
	}
}
