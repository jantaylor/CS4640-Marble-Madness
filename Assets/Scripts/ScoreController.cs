using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int playerOneScore;

    public int playerTwoScore;

    public int bonusScore;

	// Use this for initialization
	void Start () {
        LoadScores();
	}
	
	// Update is called once per frame
	void Update () {
		
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
