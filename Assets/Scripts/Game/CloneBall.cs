using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBall : MonoBehaviour {

	public GameObject bala;
	public GameObject vacio;





	public float fuerza;
	public float tiempobala;
	private GameObject copia;

	private float next;
	private float espera;
	//public GameObject canyon;
	// Use this for initialization

	private GameObject pj;
	void Start () {

		pj = (GameObject)GameObject.FindGameObjectWithTag ("Player");

		tiempobala = 30.0f;
		espera = 20.0f;

	}

	// Update is called once per frame
	void Update () {

		this.gameObject.transform.position = new Vector2 (pj.transform.position.x, pj.transform.position.y + 65.0f);

		if (GameLogic.makeClone == true) {
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);
				Destroy (copia.gameObject, tiempobala);
				next = Time.time + espera;
				GameLogic.makeClone = false;
			}
		}


	}
}
