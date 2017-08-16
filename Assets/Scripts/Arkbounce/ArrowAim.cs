using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		followMouseCursor ();
		touchDirection ();
		
	}

	void followMouseCursor()
	{
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint (mousePos);
		lookPos = lookPos - transform.position;

		float angle = Mathf.Atan2 (lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = angle - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
	void touchDirection()
	{	
			
		Vector3 touchPos = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 10);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint (touchPos);
		lookPos = lookPos - transform.position;

		float angle = Mathf.Atan2 (lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = angle - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	}
}
