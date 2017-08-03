using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsM : MonoBehaviour {

	private float puntoInicialX;
	private float pong;
	public float speed = 45.0f;
	// Use this for initialization





	void Start () {

		puntoInicialX = this.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {

		pong = Mathf.PingPong (Time.time * speed, 80);

		this.gameObject.transform.position = new Vector3 (pong + puntoInicialX, transform.position.y, transform.position.z);
	}
}
