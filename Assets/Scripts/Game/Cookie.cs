using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Respawn" || collision.gameObject.tag == "Player")  {

			GameLogic.makeClone = true;
			Destroy (this.gameObject);
		}
		if(collision.gameObject.tag == "GameOver")
		{
			Destroy (this.gameObject);
		}
	}
}
