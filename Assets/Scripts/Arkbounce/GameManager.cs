using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance;

	public int setTouches;

	public bool isMenu = false;

	public GameObject restart;
	public GameObject nextL;
	private BallArk ball;
	private PlayerArk pspeed;
	private Arbrito arb;

	public GameObject[] liveshow;

	public GameObject Live1;
	public GameObject Live2;
	public GameObject Live3;

	private float maxDefenses;
	private GameObject[] allD;

	public GameObject[] formationPrefabs;

	public int score;
	public static int oldScore;

	public int lives = 4;
	public float timeMenu = 1.0f;
	public static bool CantRestart = false;

	public static bool arbrito = true;

	public static int currentLevel = 1;

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

	private ExplodeLife liveE;
	private GameObject player;
	private GameObject playerSpawn;
	private float pspawn;

	public GameObject arrow1;
	public GameObject arrow2;
	private float arrowt1;
	private float arrowt2;
	private float arrowTimer;
	private ShowSum showsum;
	public bool showArs=false;
	private bool showArsOnce = true;

	public bool x2Boost = false;
	private float tBoost;

	private float puntoInicialXL;
	private float puntoInicialXR;
	private float pong1;
	private float pong2;
	public float speed = 2.0f;
	public float distance = 1.0f;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;

		} 

	}
	// Use this for initialization
	void Start ()
	{
		allD = GameObject.FindGameObjectsWithTag ("cube");
		ball = FindObjectOfType<BallArk> ();
		pspeed = FindObjectOfType<PlayerArk> ();
		arb = FindObjectOfType<Arbrito> ();
		liveE = FindObjectOfType<ExplodeLife> ();

		player = (GameObject)GameObject.FindGameObjectWithTag ("Player");
		playerSpawn = (GameObject)GameObject.FindGameObjectWithTag ("PlayerSpawn");

		showsum = FindObjectOfType<ShowSum> ();


		StartGame ();

		timeToAdvance = 0.3f;
		advanceDistance = 0.1f;

		waitforNextRow = 16.0f;
		puntoInicialXL = arrow1.transform.position.x;
		puntoInicialXR = arrow2.transform.position.x;
	}


	public void StartGame ()
	{
		

		//	currentLevel = Random.Range (1, formationPrefabs.Length + 1);
		//currentLevel = 4;

		showLives ();

		nextFormation ();
		GameManager.Instance.isMenu = true;


		//arrow1.gameObject.SetActive (false);
		//arrow2.gameObject.SetActive (false);




	}

	public void nextFormation ()
	{
		DestroyImmediate (ball.cGoal);
		DestroyImmediate (currentFormation);

		pspeed.canMove = false;
		player.gameObject.transform.position = new Vector2 (pspawn, player.transform.position.y);
		isMenu = false;

		PlayerArk.FirstShot = true;
		GameManager.oldScore = 0;
		GoalKeeper.speedkeeper = 17.0f;
		restart.gameObject.SetActive (false);
		nextL.gameObject.SetActive (false);
		//pspeed.speed = 40.0f;
		PlayerArk.canshoot = true;
		ball.speed = 60.0f;
		ball.gameObject.GetComponent<Rigidbody> ().drag = 0.0f;
		ball.gameObject.GetComponent<Rigidbody> ().angularDrag = 0.0f;
		arb.timer = 0.0f;
		ball.wini = false;
		arbrito = true;
		advance = true;
		doRow = false;
		rowTime = 0.0f;


		if (currentLevel == 1) {
			
			currentFormation = Instantiate (formationPrefabs [0]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			//currentFormation.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0.0f, 0.0f, 0.0f);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			arb.wait = 8.0f;

		}
		if (currentLevel == 2) {
			
			currentFormation = Instantiate (formationPrefabs [1]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			arb.wait = 6.0f;
		}
		if (currentLevel == 3) {
			
			currentFormation = Instantiate (formationPrefabs [2]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);		
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			arb.wait = 4.0f;
		}

		if (currentLevel == 4) {
			
			currentFormation = Instantiate (formationPrefabs [3]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			arb.wait = 3.5f;
		}


		if (currentLevel == 5) {
			
			currentFormation = Instantiate (formationPrefabs [4]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);

			arb.wait = 3.5f;
		}

		if (currentLevel == 6) {
			
			currentFormation = Instantiate (formationPrefabs [5]);
			currentFormation.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			currentFormation.transform.localScale = new Vector3 (1, 1, 1);
			arb.wait = 3.5f;
		}
		if (currentLevel > 6)
			currentLevel = 1;


	}


	void Update ()
	{
		
		//Debug.Log ("time; " +Time.time.ToString("n0"));
		//Debug.Log ("currentL " + currentLevel);
		//Debug.Log("makerow: "+ doRow);
		//if (currentLevel == 1){
			//if (showArsOnce == true) {
			//	if (showArs) {
					/*arrow1.gameObject.SetActive (true);
					arrow2.gameObject.SetActive (true);*/
					showArrows ();

				//}
			//}
			/*if(!showArs){
				arrow1.gameObject.SetActive (false);
				arrow2.gameObject.SetActive (false);
			}*/
	//	}

		if (x2Boost)
			TimeX2boost ();

		pspawn = playerSpawn.transform.position.x;
		if (score < 0)
			score = 0;

		if (!PlayerArk.FirstShot) {
			if (advance)
				AdvanceFormation ();

			if (arbrito)
				rowTime += Time.deltaTime;

			if (rowTime >= 20.0f && rowTime <= 20.1f)
				doRow = true;

			if (doRow) {			
				makeRow ();
			}

		} 
		if (lives == 0) {
			restart.gameObject.SetActive (false);
			CantRestart = true;
			timeMenu -= Time.deltaTime;

		}
		if (timeMenu <= 0) {
			timeMenu = 0.0f;
			lives = 4;
			CantRestart = false;
			currentLevel = 1;
			Application.LoadLevel (0);
		}

	}

	public void showArrows ()
	{
		/*arrow1.GetComponent<RectTransform>().anchoredPosition = new Vector3 (-17.71f, -41.0f, 0.0f);
		arrow2.GetComponent<RectTransform>().anchoredPosition = new Vector3 (17.71f, -41.0f, 0.0f);*/
		
		pong1 = Mathf.PingPong (Time.time * speed, distance);

		arrow1.gameObject.transform.position = new Vector3 (pong1+ puntoInicialXL, -41.0f, transform.position.z);

		pong2 = Mathf.PingPong (Time.time * speed, distance);

		arrow2.gameObject.transform.position = new Vector3 (pong2+ puntoInicialXR, -41.0f, transform.position.z);
	}



	

	public void GameEnd ()
	{
		GameManager.arbrito = false;
		if (!CantRestart)
			restart.gameObject.SetActive (true);
		
		pspeed.speed = 0.0f;
		advance = false;
		doRow = false;
		rowTime = 0.0f;

		minusLives ();
		DestroyLive ();
		isMenu = true;
		ball.GameEnd ();

		Destroy (arb.cardC);
		Destroy (arb.cardCR);
	
	}

	public void GameWin ()
	{
		
		
		GameManager.arbrito = false;
		advance = false;
		doRow = false;
		rowTime = 0.0f;
		ball.GameWin ();
		isMenu = true;
		Destroy (arb.cardC);
		Destroy (arb.cardCR);


	}

	public int GetScore ()
	{
		return score;
	}

	public void SetScore (int score)
	{
		this.score = score;
	}

	public void sumPoints ()
	{
		this.score++;
	}

	public void sumGoal()
	{
		this.score += 10;
	}

	void makeRow ()
	{
		if (Time.time > next) {
			if (currentLevel == 1 || currentLevel == 2 || currentLevel == 4) {
				goRow = Instantiate (formationPrefabs [6]);
				goRow.transform.SetParent (currentFormation.transform);
				//goRow.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0.0f, 130.0f, 0.0f);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			if (currentLevel == 3) {
				goRow = Instantiate (formationPrefabs [7]);
				goRow.transform.SetParent (currentFormation.transform);
				goRow.transform.localScale = new Vector3 (1, 1, 1);
			}
			if (currentLevel == 5) {
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

	void AdvanceFormation ()
	{
		countDown += Time.deltaTime;

		if (countDown >= timeToAdvance) {			
			currentFormation.transform.position = new Vector2 (currentFormation.transform.position.x, currentFormation.transform.position.y - advanceDistance);
			countDown = 0.0f;
		}
			
			

			
	}

	public int GetLives ()
	{
		return lives;
	}

	public void SetLives (int lives)
	{
		this.lives = lives;
	}

	public void minusLives ()
	{
		if (lives > 0) {
			this.lives--;
		}

	}

	void showLives ()
	{
		
		if (lives == 2) {
			Live1 = Instantiate (liveshow [0]);
			Live1.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live1.transform.localScale = new Vector3 (42, 42, 42);	
			Live1.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-114.0f, -1048.0f, 0.0f);

			
		}
		if (lives == 3) {
			Live1 = Instantiate (liveshow [0]);
			Live1.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live1.transform.localScale = new Vector3 (42, 42, 42);	
			Live1.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-114.0f, -1048.0f, 0.0f);

			Live2 = Instantiate (liveshow [1]);
			Live2.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live2.transform.localScale = new Vector3 (42, 42, 42);	
			Live2.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (6.0f, -1048.0f, 0.0f);



		}
		if (lives == 4) {
			Live1 = Instantiate (liveshow [0]);
			Live1.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live1.transform.localScale = new Vector3 (42, 42, 42);	
			Live1.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-114.0f, -1048.0f, 0.0f);

			Live2 = Instantiate (liveshow [1]);
			Live2.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live2.transform.localScale = new Vector3 (42, 42, 42);	
			Live2.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (6.0f, -1048.0f, 0.0f);

			Live3 = Instantiate (liveshow [2]);
			Live3.transform.SetParent (FindObjectOfType<Canvas> ().transform);
			Live3.transform.localScale = new Vector3 (42, 42, 42);	
			Live3.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (126.0f, -1048.0f, 0.0f);

		}

	}

	void DestroyLive ()
	{
		if (lives == 3) {
			Live3.GetComponent<ExplodeLife> ().makeExplosion ();
		}
		if (lives == 2) {
			Live2.GetComponent<ExplodeLife> ().makeExplosion ();
		}
		if (lives == 1) {
			Live1.GetComponent<ExplodeLife> ().makeExplosion ();
		}
	}


	void TimeX2boost()
	{
		tBoost += Time.deltaTime;

		if (tBoost >= 5.0f) 
		{
			x2Boost = false;
			tBoost = 0.0f;
		}
	}



}
