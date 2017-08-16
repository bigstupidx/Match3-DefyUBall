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

		if (Skins.pSkinPlayer > maxskin) {
			Skins.pSkinPlayer = 0;
		}
		if (Skins.pSkinPlayer < 0) {
			Skins.pSkinPlayer = maxskin;
		}

		if (Skins.pSkinPlayer == 0) {
			this.GetComponent<SpriteRenderer> ().sprite = defaultSprite;

		}

		if (Skins.pSkinPlayer == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = redSprite;

		}
		if (Skins.pSkinPlayer == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = greenSprite;

		}
		if (Skins.pSkinPlayer == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = messi;

		}
		if (Skins.pSkinPlayer == 4) {
			this.GetComponent<SpriteRenderer> ().sprite = ronaldo;

		}


		
	}
			
		

}
