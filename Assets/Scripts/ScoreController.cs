using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int playerOneScore;

    private int playerTwoScore;

    private int tickScore = 70;

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

    public Text bonusScoreText;

    public TimerController timerController;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        LoadScores();
        InvokeRepeating("AddTickScore", 0.0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        // TODO - disable tickScore when falling/respawn temporarily
        if (gameManager.GameOver)
            CancelInvoke();
	}

    public void AddFinishScorePlayerOne() {
        PlayerOneScore += finishScore;
    }

    public void AddFinishScorePlayerTwo() {
        if (gameManager.twoPlayers)
            PlayerTwoScore += finishScore;
    }

    public void AddTickScore() {
        PlayerOneScore += tickScore;

        if (gameManager.twoPlayers) {
            PlayerTwoScore += tickScore;
        }
    }

    public void CalculateBonusScore() {
        bonusScore = timerController.timeLeftInt * 10;
        bonusScoreText.text = "+ " + bonusScore.ToString();
    }

    private void LoadScores() {
        //playerOneScore = GameState.Instance.PlayerOneScore;
        //playerTwoScore = GameState.Instance.PlayerTwoScore;
    }

    private void SaveScores() {
        GameState.Instance.PlayerOneScore = playerOneScore;
        GameState.Instance.PlayerTwoScore = playerTwoScore;
    }
}
