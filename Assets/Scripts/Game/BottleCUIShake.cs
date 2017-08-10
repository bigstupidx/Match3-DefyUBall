using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCUIShake : MonoBehaviour {



	private float puntoInicialZ;
	private float pong;
	private float speed = 20.0f;
	// Use this for initialization
	void Start () {
		
		puntoInicialZ = this.transform.rotation.z - 17.0f;

	}
	
	// Update is called once per frame
	void Update () {

		pong = Mathf.PingPong (Time.time * speed, 25);

		this.gameObject.transform.rotation = (Quaternion.Euler (transform.rotation.x, transform.rotation.y, pong + puntoInicialZ));


	}
}
