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

    public GameObject player1;

    public GameObject player2;

    public GameObject mainCamera;

    public GameObject camera1;

    public GameObject camera2;

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
        LoadGame();
    }

    // Update is called once per frame
    void Update () {
		if (gameOver) {
            Invoke("GameFinished", 3f);
        } else if (levelComplete) {
            Invoke("GameFinished", 3f);
        } else if (playerOneFinished) {
            player1.GetComponent<MarbleController>().moveable = false;
            if (!GameState.Instance.TwoPlayers)
                levelComplete = true;
        } else if (playerTwoFinished) {
            player2.GetComponent<MarbleController>().moveable = false;
                levelComplete = true;
        }
	}

    private void GameFinished() {
        GameState.Instance.LoadMenu();
    }

    private void LoadGame() {
        twoPlayers = GameState.Instance.TwoPlayers;

        if (twoPlayers) {
            player2.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(true);
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
