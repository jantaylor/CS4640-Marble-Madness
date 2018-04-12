using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public AudioClip player1Finished;

    public AudioClip player2Finished;

    /// <summary>
    /// The audio source.
    /// </summary>
    private AudioSource audioSource;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.Instance.TwoPlayers)
            if (gameManager.playerOneFinished && gameManager.playerTwoFinished)
                gameManager.levelComplete = true;
            else
            if (gameManager.playerOneFinished)
                gameManager.levelComplete = true;
    }

    /// <summary>
    /// When a player enters the goal,
    /// they are awarded first or second place
    /// their movement stops
    /// their score is updated based on timer remaining
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            audioSource.PlayOneShot(player1Finished);
            gameManager.playerOneFinished = true;
        } else if (other.CompareTag("Player 2")) {
            audioSource.PlayOneShot(player2Finished);
            gameManager.playerTwoFinished = true;
        }
    }
}
