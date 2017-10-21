//                    COMP3064 CRN13899 Assignment 1
//                   Submitted to: Przemyslaw Pawluk
//                      Friday, October 20, 2017        
//                   From: Rajvi Lathia  - 101034808 
//                rajvimukeshbhai.lathia@georgebrown.ca

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameoverLabel;
	[SerializeField]
	Text highscoreLabel;
	[SerializeField]
	Button playagainBtn;
	[SerializeField]
	GameObject enemyship;


	// Use this for initialization
	void Start () {
		Player.Instance.gameCtrl = this;
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//sets start of the game UI
	private void initialize(){
		Player.Instance.Score = 0;
		Player.Instance.Life = 3;
		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		gameoverLabel.gameObject.SetActive (false);
		highscoreLabel.gameObject.SetActive (false);
		playagainBtn.gameObject.SetActive (false);
		StartCoroutine ("AddEnemyship");//starts coroutine called AddEnemyship
	}

	//shows game over, high score and play again button
	//hides life and score label
	public void gameOver(){
		Player.Instance.Highscore = Player.Instance.Score;
		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		gameoverLabel.gameObject.SetActive (true);
		highscoreLabel.gameObject.SetActive (true);
		playagainBtn.gameObject.SetActive (true);
	}

	//updates UI 
	public void updateUI(){
		lifeLabel.text = "Life:" + Player.Instance.Life;
		scoreLabel.text = "Score: " + Player.Instance.Score;
		highscoreLabel.text = "Your Score: " + Player.Instance.Highscore;
	}
		
	// This method is called when play again button is clicked
	// Restarts the game
	public void PlayagainBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	private IEnumerator AddEnemyship(){
		int time = Random.Range (0, 5);
		yield return new WaitForSeconds ((float) time);
		Instantiate (enemyship); //calls instantiate method/function
		StartCoroutine ("AddEnemyship");
	}
}