using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSum : MonoBehaviour
{

	private Text pluScore;
	public int plus;
	private float timer = 5.0f;
	// Use this for initialization
	void Start ()
	{

		pluScore = GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
    //ShowSumScore
	public int showPlus (int plus)
	{
		
		if (plus == 0)
			pluScore.text = "";
		
		if (plus == 1)
			pluScore.text = "+" + plus.ToString ();

		if (plus == 2)
			pluScore.text = "+" + plus.ToString ();
		
		if (plus == 10)
			pluScore.text = "+" + plus.ToString ();



		return plus;
		
	}
}
