using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour {

	// Use this for initialization

	public Transform target;


	void Start () {
		




	}
	
	// Update is called once per frame
	void Update () {
		

		this.transform.LookAt(target);



		
	}
}
