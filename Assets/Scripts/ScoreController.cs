using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int playerOneScore;

    private int playerTwoScore;

    private int tickScore = 10;

    private int finishScore = 1000;

    public int PlayerOneScore {
        get { return playerOneScore; }
        set {
            playerOneScore = value;
            playerOneScoreText.text = playerOneScore.ToString();
        }
    }

    public int PlayerTwoScore {
        get { return playerTwoScore; }
        set {
            playerTwoScore = value;
            playerTwoScoreText.text = playerTwoScore.ToString();
        }
    }

    public int bonusScore;

    public Text playerOneScoreText;

    public Text playerTwoScoreText;

    public TimerController timerController;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        LoadScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddFinishScore() {
        
    }

    public int CalculateBonusScore() {
        return timerController.timeLeftInt * 10;
    }

    private void LoadScores() {
        playerOneScore = GameState.Instance.PlayerOneScore;
        playerTwoScore = GameState.Instance.PlayerTwoScore;
    }

    private void SaveScores() {
        GameState.Instance.PlayerOneScore = playerOneScore;
        GameState.Instance.PlayerTwoScore = playerTwoScore;
    }
}
