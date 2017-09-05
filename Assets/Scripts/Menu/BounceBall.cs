using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Respawn")
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0, 20,0);
	}
}
