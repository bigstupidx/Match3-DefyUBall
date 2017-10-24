using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	private GameObject formation1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnMouseUp ()
	{
		PlayerArk.FirstShot = true;
		GoalKeeper.speedkeeper = 17.0f;
        GameManagerArk.arbrito = true;
        GameManagerArk.oldScore = 0;
        GameManagerArk.currentLevel++;
		Input.ResetInputAxes ();
        GameManagerArk.Instance.nextFormation ();
        gameObject.SetActive(false);
    }
}