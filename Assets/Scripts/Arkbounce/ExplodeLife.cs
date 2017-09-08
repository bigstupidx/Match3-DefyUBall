using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeLife : MonoBehaviour {


	private Animator anim;
	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator> ();

		anim.SetBool ("Explode", false);
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void makeExplosion()
	{
		anim.SetBool ("Explode", true);
		Destroy (gameObject, 1.0f);
	}
}
