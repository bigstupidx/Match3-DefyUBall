using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;


	public GameObject restart;
	public GameObject nextL;
	private BallArk ball;
	private PlayerArk pspeed;
	private Arbrito arb;


	private float maxDefenses;
	private GameObject[] allD;

	public GameObject[] formationPrefabs;

	public int score;
	public static int oldScore;

	public static bool arbrito = true;

	public static int currentLevel = 1;

	private GameObject formation1;

	public GameObject go1;
	public GameObject go2;
	public GameObject go3;



	void Awake(){
		if (Instance == null) {
			Instance = this;
			//DontDestroyOnLoad (gameObject);
		} 

	}
	// Use this for initialization
	void Start () {
		allD = GameObject.FindGameObjectsWithTag("cube");
		ball = FindObjectOfType<BallArk>();
		pspeed = FindObjectOfType<PlayerArk>();
		arb = FindObjectOfType<Arbrito>();


		StartGame ();
	}


	public void StartGame()
	{
		GameManager.oldScore = 0;
		restart.gameObject.SetActive (false);
		nextL.gameObject.SetActive (false);
		pspeed.speed = 100.0f;
		pspeed.canshoot = true;
		ball.speed = 80.0f;
		arb.timer = 0.0f;
		ball.wini = false;
		arbrito = true;
		if (currentLevel == 1) 
		{
			go1 = Instantiate (formationPrefabs [0]);
			go1.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			go1.transform.localScale = new Vector3 (1, 1, 1);
		}

		nextFormation ();

		
	}
	public void nextFormation()
	{
		if (currentLevel == 2) 
		{
			Destroy (go1.gameObject);
			go2 = Instantiate(formationPrefabs[1]);
			go2.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			go2.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (currentLevel == 3) 
		{
			Destroy (go2.gameObject);
			go3 = Instantiate(formationPrefabs[2]);
			go3.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			go3.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (currentLevel > 3)
			currentLevel = 1;
		
	}
	void Update()
	{
		if (score < 0)
			score = 0;

	}

	public void GameEnd()
	{
		GameManager.arbrito = false;
		restart.gameObject.SetActive (true);
		pspeed.speed = 0.0f;
		ball.GameEnd ();
	
	} 
	public void GameWin()
	{
		GameManager.arbrito = false;
		ball.GameWin ();

	} 

	public int GetScore()
	{
		return score;
	}
	public void SetScore(int score)
	{
		this.score = score;
	}
	public void sumPoints()
	{
		this.score++;
	}

}
