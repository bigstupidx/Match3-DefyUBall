using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {

	private float rotSpeed = 600.0f;

	// Use this for initialization
	private bool rotateL = false;
	private bool rotateR = false;
	private GameObject pjx;

	void Start () {
		pjx = (GameObject)GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Ball.firstTouch == true) {
			if (Ball.canRotate == true) {
				if (this.gameObject.transform.position.x < pjx.gameObject.transform.position.x) {
				
					rotateL = true;
					rotateR = false;
				}
				if (this.gameObject.transform.position.x > pjx.gameObject.transform.position.x) {
					rotateR = true;
					rotateL = false;
				}
			}

		}
		if (rotateL == true) 
		{
			this.gameObject.GetComponent<RectTransform>().localRotation = (Quaternion.Euler (0.0f, 0.0f, rotSpeed * Time.time));

		}
		if (rotateR == true) 
		{
			this.gameObject.GetComponent<RectTransform>().localRotation = (Quaternion.Euler (0.0f, 0.0f, -rotSpeed * Time.time));
		}

		if (GameLogic.GameOver == true) 
		{
			Ball.canRotate = false;
			rotateL = false;
			rotateR = false;
		}
		
	}
}
