using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYellow : MonoBehaviour {

	// Use this for initialization
	private float rotSpeed = 1500.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			gameObject.GetComponent<RectTransform>().localRotation = (Quaternion.Euler (0.0f, 0.0f, rotSpeed * Time.time));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "GameOver") 
		{
			Destroy (this.gameObject);
		}
	}
}
