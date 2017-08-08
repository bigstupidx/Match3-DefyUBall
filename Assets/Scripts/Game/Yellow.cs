using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour {

	//public GameObject hit;


	// Use this for initialization
	void Start () {


		
	}

	// Update is called once per frame
	void Update () {
			//hit.gameObject.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y);

	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Respawn")  {

			//hit.gameObject.SetActive (true);
			GameLogic.Stun = true;
			Destroy (this.gameObject);

		}
		if (collision.gameObject.tag == "GameOver") {
			Destroy (this.gameObject);
		}
	}
}

