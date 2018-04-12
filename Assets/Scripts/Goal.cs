using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    /// <summary>
    /// The audio source.
    /// </summary>
    public AudioSource audioSource;

    public GameManager gameManager;

    public bool playerOneFinished;

    public bool playerTwoFinished;

	// Use this for initialization
	void Start () {
		///know maximum number of players

	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.Instance.TwoPlayers)
            if (playerOneFinished && playerTwoFinished)
                Invoke("GameFinished", 3f);
        else
            if (playerOneFinished)
                Invoke("GameFinished", 3f);
    }

    private void GameFinished() {
        GameState.Instance.LoadNextScene();
    }

    /// <summary>
    /// When a player enters the goal,
    /// they are awarded first or second place
    /// their movement stops
    /// their score is updated based on timer remaining
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            // check timeleft
            // update score based on their tag
            // cease other.movement
            // translate to "1st place" location
            // or 2ndplace
            // or nth place? how may will we have?
            // Play the audiosource attached to whatever player entered
            // or 0 = player 1

            audioSource.Play();

        }
        // when maxplayers and numplayers are the same, queue next level
        // Need to set instance gameManager.levelComplete = true;
    }
}
