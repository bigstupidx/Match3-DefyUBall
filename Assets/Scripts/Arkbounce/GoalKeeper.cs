using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper: MonoBehaviour {

	private float puntoInicialX;
	private float pong;
	public static float speedkeeper = 17.0f;
	private float distance = 47.0f;
	// Use this for initialization





	void Start () {

		puntoInicialX = this.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {

		pong = Mathf.PingPong (Time.time * speedkeeper, distance);

		this.gameObject.transform.position = new Vector3 (pong + puntoInicialX, transform.position.y, transform.position.z);
	}
}
