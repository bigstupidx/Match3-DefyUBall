using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

	private float turnspeed;
	// Use this for initialization
	void Start () {

		turnspeed = 85.0f;
	}

	// Update is called once per frame
	void Update () {

		this.gameObject.transform.Rotate (new Vector3 (0.0f, 0.0f, turnspeed * Time.deltaTime));
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "GameOver" || collision.gameObject.tag == "Respawn" || collision.gameObject.tag == "Respawn")  {

			GameLogic.moreSpeed = true;
			Destroy (this.gameObject);
		}
	}
}
