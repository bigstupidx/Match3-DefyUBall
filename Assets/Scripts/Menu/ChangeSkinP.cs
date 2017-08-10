using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinP : MonoBehaviour {



	public Sprite defaultSprite;
	public Sprite redSprite;
	public Sprite greenSprite;
	public Sprite messi;
	public Sprite ronaldo;

	private int maxskin = 4;
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameLogic.pSkinPlayer > maxskin) {
			GameLogic.pSkinPlayer = 0;
		}
		if (GameLogic.pSkinPlayer < 0) {
			GameLogic.pSkinPlayer = maxskin;
		}

		if (GameLogic.pSkinPlayer == 0) {
			this.GetComponent<SpriteRenderer> ().sprite = defaultSprite;

		}

		if (GameLogic.pSkinPlayer == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = redSprite;

		}
		if (GameLogic.pSkinPlayer == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = greenSprite;

		}
		if (GameLogic.pSkinPlayer == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = messi;

		}
		if (GameLogic.pSkinPlayer == 4) {
			this.GetComponent<SpriteRenderer> ().sprite = ronaldo;

		}


		
	}
			
		

}
