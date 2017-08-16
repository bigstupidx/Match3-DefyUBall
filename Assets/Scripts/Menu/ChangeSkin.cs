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
			

		if (Skins.pSkinBall > 2) {
			Skins.pSkinBall = 0;
			}
		if (Skins.pSkinBall < 0) {
			Skins.pSkinBall = 2;
			}


		if (Skins.pSkinBall == 0) {
				this.GetComponent<SpriteRenderer> ().sprite = defaultSprite;

			}

		if (Skins.pSkinBall == 1) {
				this.GetComponent<SpriteRenderer> ().sprite = redSprite;

			}
		if (Skins.pSkinBall == 2) {
				this.GetComponent<SpriteRenderer> ().sprite = greenSprite;

			}
		
	}


}
