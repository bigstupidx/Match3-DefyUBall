using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDouble : MonoBehaviour {

	private float turnspeed;
	// Use this for initialization
	void Start () {
		turnspeed = 75.0f;
		
	}

	// Update is called once per frame
	void Update () {

		this.gameObject.transform.Rotate (new Vector3 (0.0f, turnspeed * Time.deltaTime, 0.0f));
		
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "GameOver" || collision.gameObject.tag == "Respawn")  {

			GameLogic.DoubleP = true;
			Destroy (this.gameObject);
		}
	}
}
