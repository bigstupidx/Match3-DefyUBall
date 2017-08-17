using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	private GameObject pj;
	private Text CurrentScore;

	// Use this for initialization
	void Start ()
	{
		CurrentScore = GetComponent<Text>();
		pj = (GameObject)GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		CurrentScore.text = pj.GetComponent<PlayerArk>().GetScore().ToString();
	}
}
