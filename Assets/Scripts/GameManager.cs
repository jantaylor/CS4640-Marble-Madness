using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// current player's score
    /// </summary>
    private int currentScore;

    /// <summary>
    /// Boolean to hold if the game is over or not
    /// </summary>
    private bool gameOver;

    /// <summary>
    /// Boolean to hold if the level is completed
    /// </summary>
    private bool levelComplete;

    /// <summary>
    /// Public Score
    /// </summary>
    public int CurrentScore {
        get { return currentScore; }
        set { currentScore = value; }
    }

	// Use this for initialization
	void Start () {
        currentScore = GameState.Instance.Score;
        gameOver = false;
        levelComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
            // TODO
            return;
        } else if (levelComplete) {
            // TODO
            return;
        }
        return;
	}
}
