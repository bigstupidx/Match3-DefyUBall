using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour {

	// Use this for initialization

	public Transform target;

	private GameObject player;
	private float playerpos;
	private GameObject card;

	void Start () {
		
		card =  GameObject.FindGameObjectWithTag ("yellow");
		player =  GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {
		playerpos = player.transform.position.y;

		this.transform.LookAt(target);

		//card.transform.rotation = Quaternion.Euler(0.0f, 0.0f, card.transform.localRotation.z );

		
	}
}
