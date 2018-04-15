using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    /// <summary>
    /// Start a new game
    /// </summary>
    public void NewGame() {
        // Start a new game
        GameState.Instance.LoadNextScene();
    }

    /// <summary>
    /// Start new online multiplayer lobby
    /// </summary>
    public void OnlineMultiplayer() {
        // TODO
    }

    /// <summary>
    /// Start a new local multiplayer lobby
    /// </summary>
    public void LocalMultiplayer() {
        GameState.Instance.TwoPlayers = true;
        GameState.Instance.ActiveScene = 4;
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Test");
    }

    /// <summary>
    /// Load the High Scores
    /// </summary>
    public void HighScores() {
        GameState.Instance.LoadHighScores();
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void Quit() {
        Application.Quit();
    }
}
