using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDOUBLE : MonoBehaviour {


	public GameObject bala;
	public GameObject vacio;


	private bool dup = false;


	public float fuerza;
	public float tiempobala;
	private GameObject copia;

	private float next;
	private float espera;
	//public GameObject canyon;
	// Use this for initialization
	void Start () {

		fuerza = 1.0f;
		tiempobala = 30.0f;
		espera = 10.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((GameLogic.Points == 10) ){
			
			dup = true;
		}
		if(dup == true)
		{
			if (Time.time > next) {
				copia = (GameObject)Instantiate (bala, vacio.transform.position, bala.transform.rotation);
				//copia.transform.localScale = new Vector3 (21.0f,21.0f,21.0f);
				//copia.gameObject.GetComponent<Rigidbody>().velocity = -canyon.transform.up * fuerza;
				Destroy (copia.gameObject, tiempobala);
				next = Time.time + espera;
			}
		}
		if ((GameLogic.Points == 20) ){

			espera = 8.0f;
		}
		if ((GameLogic.Points == 30) ){

			espera = 5.0f;
		}
		if ((GameLogic.Points == 40) ){

			espera = 4.0f;
		}

		if ((GameLogic.Points == 50) ){

			espera = 3.0f;
		}
		if (GameLogic.GameOver == true) 
		{
			dup = false;
		}
	


	}
}
