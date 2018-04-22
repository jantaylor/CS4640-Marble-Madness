using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool playerOneFinished = false;

    public bool playerTwoFinished = false;

    public bool twoPlayers = false;

    /// <summary>
    /// Boolean to hold if the game is over or not
    /// </summary>
    public bool gameOver;

    public MarbleController player1;

    public MarbleController player2;

    public GameObject mainCamera;

    public GameObject camera1;

    public GameObject camera2;

    public ScoreController scoreController;

    /// <summary>
    /// If the player dies by falling we needn't animate
    /// </summary>
    private bool playerDeathByFall;

    /// <summary>
    /// If the player dies, otherwise, there's usually a "dustpan" animation
    /// </summary>
    private bool playerDeathByEnemy;

    /// <summary>
    /// Boolean to hold if the level is completed
    /// </summary>
    public bool levelComplete;

    /// <summary>
    /// Public Game Over
    /// </summary>
    public bool GameOver {
        get { return gameOver; }
        set { gameOver = value; }
    }

	// Use this for initialization
	void Start () {
        scoreController = FindObjectOfType<ScoreController>();
        LoadGame();
    }

    // Update is called once per frame
    void Update() {

        // check for game over
        if (playerOneFinished && playerTwoFinished && twoPlayers) {
            levelComplete = true;
        } else if (playerOneFinished && !twoPlayers) {
            player1.moveable = false;
            levelComplete = true;
        }

        // game over and level finished scenarios
        if (gameOver) {
            scoreController.SaveScores();
            Invoke("GameFinished", 3f);
        } else if (levelComplete) {
            scoreController.SaveScores();
            Invoke("LevelFinished", 3f);
        }

        // set movement to false upon finishing
        if (playerOneFinished && twoPlayers) {
            player1.moveable = false;
        } else if (playerTwoFinished && twoPlayers) {
            player2.moveable = false;
        } 
	}

    private void LevelFinished() {
        //GameState.Instance.LoadMenu();
        GameState.Instance.LoadNextScene();
    }

    private void GameFinished() {
        GameState.Instance.CanSubmitHighScore = true;
        GameState.Instance.LoadHighScores();
    }

    private void LoadGame() {
        if (GameState.Instance.ActiveScene != 0) {
            twoPlayers = GameState.Instance.TwoPlayers;
            mainCamera.gameObject.SetActive(true);
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(false);

            if (twoPlayers) {
                player2.gameObject.SetActive(true);
                mainCamera.gameObject.SetActive(false);
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(true);
            }
        }

        playerOneFinished = false;
        playerTwoFinished = false;
        gameOver = false;
        levelComplete = false;
    }

    private void SaveGame() {
        // TODO
    }
}
