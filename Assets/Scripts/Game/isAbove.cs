using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAbove : MonoBehaviour {

	private GameObject ball;
	private GameObject arrow;

	// Use this for initialization
	void Start () {
		ball =  (GameObject)GameObject.FindGameObjectWithTag ("Ball");
		arrow = (GameObject)GameObject.FindGameObjectWithTag ("arrowup");
		arrow.SetActive (false);


	}

	// Update is called once per frame
	void Update () {
		arrow.gameObject.transform.position = new Vector2 (ball.transform.position.x, arrow.transform.position.y);
		//arrow.gameObject.transform.position.x = ball.gameObject.GetComponent<RectTransform>().position.x;

		if (ball.gameObject.transform.position.y > this.gameObject.transform.position.y) {
			arrow.SetActive (true);
			
		} else {
			arrow.SetActive (false);
		}
	}
}
