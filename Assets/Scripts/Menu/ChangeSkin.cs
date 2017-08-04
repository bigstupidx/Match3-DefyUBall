using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour {



	public Sprite defaultSprite;
	public Sprite redSprite;
	public Sprite greenSprite;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () 
	{
			

			if (GameLogic.pSkinBall > 2) {
				GameLogic.pSkinBall = 0;
			}
			if (GameLogic.pSkinBall < 0) {
				GameLogic.pSkinBall = 2;
			}


			if (GameLogic.pSkinBall == 0) {
				this.GetComponent<SpriteRenderer> ().sprite = defaultSprite;

			}

			if (GameLogic.pSkinBall == 1) {
				this.GetComponent<SpriteRenderer> ().sprite = redSprite;

			}
			if (GameLogic.pSkinBall == 2) {
				this.GetComponent<SpriteRenderer> ().sprite = greenSprite;

			}
		
	}


}
