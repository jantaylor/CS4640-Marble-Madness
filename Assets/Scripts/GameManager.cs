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

    public GameObject player2;

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
    private bool levelComplete;

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
            // TODO
            GameState.Instance.LoadMenu();
        } else if (levelComplete) {
            // TODO
            GameState.Instance.LoadMenu();
            return;
        }
        return;
	}

    private void LoadGame() {
        twoPlayers = GameState.Instance.TwoPlayers;

        if (twoPlayers) {
            player2.gameObject.SetActive(true);
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
