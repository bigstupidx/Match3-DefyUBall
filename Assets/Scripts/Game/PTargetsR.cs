﻿using System.Collections;
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



	// Use this for initialization
	void Start ()
	{



		espera = 10.0f;


	}

	// Update is called once per frame
	void Update ()
	{

		if (GameLogic.Points == 45)
		{
			if (GameLogic.GameOver == false) {
				dup = true;
			}

		}
		if (dup == true) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);

				next = Time.time + espera;

			}

		}
		if (GameLogic.GameOver == true) 
		{
			dup = false;
		}

	}
}


