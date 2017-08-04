using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	private Text spoints;
	void Start () {
		spoints = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		spoints.text = GameLogic.Points.ToString();
		
	}
}
