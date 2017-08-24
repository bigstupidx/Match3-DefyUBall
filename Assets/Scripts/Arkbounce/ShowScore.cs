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
	/*void Awake()
	{
		CurrentScore.text = GameManager.Instance.SetScore().ToString();
	}*/

	// Update is called once per frame
	void Update () 
	{
		CurrentScore.text = GameManager.Instance.GetScore().ToString();
	}

	//score

}
