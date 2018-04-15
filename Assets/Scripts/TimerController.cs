using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    /// <summary>
    /// Game Manager object
    /// </summary>
    public GameManager gameManager;

    /// <summary>
    /// Game Timer object
    /// </summary>
    public Text gameTimer;

    /// <summary>
    /// Current time in level
    /// </summary>
    public float timeLeft = 90;

    public int timeLeftInt;

    public int bonusTime = 0;

    public bool timerStopped = false;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Count down timer
	void Update () {
        if (gameManager.gameOver || gameManager.levelComplete || (gameManager.playerOneFinished && gameManager.playerTwoFinished))
            return;

        timeLeft -= Time.deltaTime;
        timeLeftInt = (int)timeLeft;
        gameTimer.text = timeLeftInt.ToString();
        if (timeLeft <= 0) {
            gameManager.GameOver = true;
        }
    }
}
