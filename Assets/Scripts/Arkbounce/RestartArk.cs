using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartArk : MonoBehaviour {

	private GameManagerArk score;
	private GameManagerArk formations;
	//private GameManager keepscore;
	//private Arbrito arb;


	// Use this for initialization
	void Start () {
		score = FindObjectOfType<GameManagerArk>();
		formations = FindObjectOfType<GameManagerArk>();
		//keepscore = FindObjectOfType<GameManager>();
		//arb = FindObjectOfType<Arbrito>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnMouseUp(){			

			Input.ResetInputAxes ();
        //GameManager.Instance.isMenu = false;

        GameManagerArk.arbrito = true;

			score.score -= GameManagerArk.oldScore;
        GameManagerArk.oldScore = 0;
        GameManagerArk.Instance.nextFormation ();

	}
}
