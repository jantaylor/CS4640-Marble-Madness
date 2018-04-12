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

    private bool playerOneScoreGiven = false;

    private bool playerTwoScoreGiven = false;   

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        LoadScores();

        // Hide the player 2 score if not a two player game
        if (!GameState.Instance.TwoPlayers)
            playerTwoScoreText.gameObject.SetActive(false);

        InvokeRepeating("AddTickScore", 0.0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.playerOneFinished && !playerOneScoreGiven)
            AddFinishScorePlayerOne();
        if (gameManager.playerTwoFinished && !playerTwoScoreGiven)
            AddFinishScorePlayerTwo();

        // TODO - disable tickScore when falling/respawn temporarily
        if (gameManager.GameOver || gameManager.levelComplete)
            CancelInvoke();
	}

    public void AddFinishScorePlayerOne() {
        PlayerOneScore += finishScore;
        CalculateBonusScore("p1");
        playerOneScoreGiven = true;
    }

    public void AddFinishScorePlayerTwo() {
        PlayerTwoScore += finishScore;
        CalculateBonusScore("p2");
        playerTwoScoreGiven = true;
    }

    public void AddTickScore() {
        PlayerOneScore += tickScore;

        if (gameManager.twoPlayers) {
            PlayerTwoScore += tickScore;
        }
    }

    public void CalculateBonusScore(string p) {
        bonusScore = timerController.timeLeftInt * 10;
        bonusScoreText.text = "+ " + bonusScore.ToString();
        if (p == "p1")
            PlayerOneScore += bonusScore;
        else
            PlayerTwoScore += bonusScore;
        bonusScoreText.gameObject.SetActive(true);
        Invoke("HideBonusScore", 2f);
    }

    private void HideBonusScore() {
        bonusScoreText.gameObject.SetActive(false);
    }

    private void LoadScores() {
        playerOneScore = GameState.Instance.PlayerOneScore;
        if (GameState.Instance.TwoPlayers)
            playerTwoScore = GameState.Instance.PlayerTwoScore;
    }

    private void SaveScores() {
        GameState.Instance.PlayerOneScore = playerOneScore;
        if (GameState.Instance.TwoPlayers)
            GameState.Instance.PlayerTwoScore = playerTwoScore;
    }
}
