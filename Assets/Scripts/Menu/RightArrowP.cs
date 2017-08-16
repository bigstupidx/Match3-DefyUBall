using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowP : MonoBehaviour {

	private float puntoInicialX;
	private float pong;
	public float speed = 2.0f;
	public float distance = 1.0f;
	// Use this for initialization





	void Start () {

		puntoInicialX = this.transform.position.x;


	}

	// Update is called once per frame
	void Update () {

		pong = Mathf.PingPong (Time.time * speed, distance);

		this.gameObject.transform.position = new Vector3 (pong + puntoInicialX, transform.position.y, transform.position.z);
	}
	void OnMouseDown()
	{
		Skins.pSkinPlayer += 1;


	}
}
