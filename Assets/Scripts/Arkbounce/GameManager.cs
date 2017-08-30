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



	public GameObject go1;
	public GameObject go2;
	public GameObject go3;
	public GameObject go4;
	public GameObject go5;
	public GameObject go6;

	public GameObject currentFormation;

	public GameObject goRow;

	private float timeToAdvance;
	public bool advance;
	private float advanceDistance;


	public bool doRow;
	private float next;
	private float waitforNextRow;
	private float rowTime;

	//private int rand;

	public float countDown;
	private float countDownR;


	private GameObject defense;
	private GameObject limitDefense;

	void Awake(){
		if (Instance == null) 
		{
			Instance = this;

		} 

	}
	// Use this for initialization
	void Start () {
		allD = GameObject.FindGameObjectsWithTag("cube");
		ball = FindObjectOfType<BallArk>();
		pspeed = FindObjectOfType<PlayerArk>();
		arb = FindObjectOfType<Arbrito>();



		StartGame ();

		timeToAdvance = 0.1f;
		advanceDistance = 0.1f;

		waitforNextRow = 9.0f;
	}


	public void StartGame()
	{
		

	//	currentLevel = Random.Range (1, formationPrefabs.Length + 1);
		//currentLevel = 4;

		//arb.gospot3 = true;
		nextFormation ();


	}

	public void nextFormation()
	{

		DestroyImmediate (currentFormation);

		GameManager.oldScore = 0;
		restart.gameObject.SetActive (false);
		nextL.gameObject.SetActive (false);
		pspeed.speed = 100.0f;
		pspeed.canshoot = true;
		ball.speed = 80.0f;
		ball.gameObject.GetComponent<Rigidbody>().drag = 0.0f;
		ball.gameObject.GetComponent<Rigidbody>().angularDrag = 0.0f;
		arb.timer = 0.0f;
		ball.wini = false;
		arbrito = true;
		advance = true;
		doRow = false;
		rowTime = 0.0f;

		if (currentLevel == 1) 
		{
			
			currentFormation = Instantiate (formationPrefabs [0]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);

		}
		if (currentLevel == 2) 
		{
			
			currentFormation = Instantiate(formationPrefabs[1]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (currentLevel == 3) 
		{
			
			currentFormation = Instantiate(formationPrefabs[2]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
		}

		if (currentLevel == 4) 
		{
			
			currentFormation = Instantiate(formationPrefabs[3]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
		}


		if (currentLevel == 5) 
		{
			
			currentFormation = Instantiate(formationPrefabs[4]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
		}

		if (currentLevel == 6) 
		{
			
			currentFormation = Instantiate(formationPrefabs[5]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (currentLevel > 6)
			currentLevel = 1;


	}


	void Update()
	{
		//Debug.Log ("time; " +Time.time.ToString("n0"));
		//Debug.Log ("currentL " + currentLevel);
		Debug.Log("makerow: "+ doRow);

		if (score < 0)
			score = 0;

		if (!PlayerArk.FirstShot) {
			if (advance)
				AdvanceFormation ();

			if (arbrito)
				rowTime += Time.deltaTime;

			if (rowTime >= 10.0f && rowTime <= 10.1f)
				doRow = true;

			if (doRow) {			
				makeRow ();
			}

		}
	

	}



	public void GameEnd()
	{
		GameManager.arbrito = false;
		restart.gameObject.SetActive (true);
		pspeed.speed = 0.0f;
		advance = false;
		doRow = false;
		rowTime = 0.0f;
		ball.GameEnd ();
	
	} 
	public void GameWin()
	{
		GameManager.arbrito = false;
		advance = false;
		doRow = false;
		rowTime = 0.0f;
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

	void makeRow()
	{
		if (Time.time > next)
		{
			if (currentLevel == 1 ||currentLevel == 2 ) {
				goRow = Instantiate (formationPrefabs [6]);
				goRow.transform.SetParent (currentFormation.transform);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			if (currentLevel == 3) {
				goRow = Instantiate (formationPrefabs [7]);
				goRow.transform.SetParent (currentFormation.transform);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			if (currentLevel == 4 ||currentLevel == 5) {
				goRow = Instantiate (formationPrefabs [8]);
				goRow.transform.SetParent (currentFormation.transform);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			if (currentLevel == 6) {
				goRow = Instantiate (formationPrefabs [9]);
				goRow.transform.SetParent (currentFormation.transform);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			next = Time.time + waitforNextRow;
		}
	}
	void AdvanceFormation()
	{
		countDown += Time.deltaTime;

			if (countDown >= timeToAdvance) {
			if (currentFormation == null) 
			{
				currentFormation = Instantiate (formationPrefabs [0]);
				currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
				currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			}
				currentFormation.transform.position = new Vector2 (currentFormation.transform.position.x, currentFormation.transform.position.y - advanceDistance);
				countDown = 0.0f;
			}
			
			

			
	}

}
