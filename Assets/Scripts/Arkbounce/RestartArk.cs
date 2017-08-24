using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartArk : MonoBehaviour {

	private GameManager score;
	private GameManager formations;
	//private GameManager keepscore;


	// Use this for initialization
	void Start () {
		score = FindObjectOfType<GameManager>();
		formations = FindObjectOfType<GameManager>();
		//keepscore = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnMouseDown(){
		PlayerArk.FirstShot = true;
		GoalKeeper.speedkeeper = 17.0f;
		GameManager.arbrito = true;
		PlayerArk.FirstShot = true;
		score.score -= GameManager.oldScore;
		GameManager.oldScore = 0;
		Destroy (formations.go1);
		Destroy (formations.go2);
		Destroy (formations.go3);
		GameManager.Instance.StartGame ();

	}
}
