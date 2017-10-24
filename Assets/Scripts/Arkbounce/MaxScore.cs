using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour {

	// Use this for initialization

	public static float GetMaxScore;

	private Text CurrentScore;

	void Start () 
	{
		
		DontDestroyOnLoad (gameObject);
		CurrentScore = GetComponent<Text>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameManagerArk.Instance.score>GetMaxScore)
			GetMaxScore = GameManagerArk.Instance.GetScore();


		CurrentScore.text = "MAX SCORE: " + GetMaxScore.ToString();
	}
}
