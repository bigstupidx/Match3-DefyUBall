using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCookie : MonoBehaviour {

	public GameObject bala;
	public GameObject vacio;


	private bool dup = false;


	public float tiempobala;
	private GameObject copia;

	private float next;
	private float espera;
	//public GameObject canyon;
	// Use this for initialization
	void Start () {


		tiempobala = 30.0f;
		espera = 10.0f;

	}

	// Update is called once per frame
	void Update () {

		if (GameLogic.Points == 30)
		{
			dup = true;

		}
		if (dup == true) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);
				Destroy (copia.gameObject, tiempobala);
				next = Time.time + espera;

			}
		}
		if (GameLogic.Points == 30)
		{
			espera = 5.0f;

		}

		}



	}

