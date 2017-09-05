using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour {

	// Use this for initialization

	public static int GetMaxScore;

	private Text CurrentScore;

	void Start () 
	{
		
		DontDestroyOnLoad (gameObject);
		CurrentScore = GetComponent<Text>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameManager.Instance.score>GetMaxScore)
			GetMaxScore = GameManager.Instance.GetScore();


		CurrentScore.text = "MAX SCORE: " + GetMaxScore.ToString();
	}
}
