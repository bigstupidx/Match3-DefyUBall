using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDOUBLE : MonoBehaviour {


	public GameObject bala;
	public GameObject vacio;

	public float fuerza;
	public float tiempobala;
	private GameObject copia;
	private float next;
	private float espera;
	//public GameObject canyon;
	// Use this for initialization
	void Start () {

		fuerza = 1.0f;
		tiempobala = 20.0f;
		espera = 20.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLogic.Points == 10) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);
				//copia.gameObject.GetComponent<Rigidbody>().velocity = -canyon.transform.up * fuerza;
				Destroy (copia.gameObject, tiempobala);
				next = Time.time + espera;
			}
		}
	}
}
