using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBottleC : MonoBehaviour {

	public GameObject bala;
	public GameObject vacio;


	private bool dup = false;


	public float tiempobala;
	private GameObject copia;

	private float next;
	private float espera;
	//public GameObject canyon;
	// Use this for initialization
	private GameObject bottlecui;
	void Start () {
		bottlecui = (GameObject)GameObject.FindGameObjectWithTag ("bottleui");
		bottlecui.gameObject.SetActive (false);
		tiempobala = 30.0f;
		espera = 10.0f;

	}

	// Update is called once per frame
	void Update () {

		if (GameLogic.showBig == true) {
			bottlecui.gameObject.SetActive (true);
		}


		if (GameLogic.Points == 2/*18*/ && GameLogic.showBig == false)
		{
			dup = true;

		}
		if (dup == true) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);				
				dup = false;
				next = Time.time + espera;

			}
		}
	}
}