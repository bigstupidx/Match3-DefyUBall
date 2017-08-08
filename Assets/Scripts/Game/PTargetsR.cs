using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTargetsR : MonoBehaviour {

	public GameObject bala;
	public GameObject vacio;
	//public GameObject audioShoot;

	private GameObject copia;
	private float next;
	private float espera;


	private bool dup = false;

	private float puntoInicialX;
	private float pong;
	private float speed = 100.0f;

	// Use this for initialization
	void Start ()
	{



		espera = 8.0f;

		puntoInicialX = this.transform.position.x;
	}

	// Update is called once per frame
	void Update ()
	{
		pong = Mathf.PingPong (Time.time * speed, 85);

		this.gameObject.transform.position = new Vector3 (pong + puntoInicialX, transform.position.y, transform.position.z);

		if (GameLogic.Points == 50)
		{
			dup = true;

		}
		if (dup == true) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);

				next = Time.time + espera;

			}

		}

	}
}


