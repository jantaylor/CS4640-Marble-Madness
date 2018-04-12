using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    /// <summary>
    /// The audio source.
    /// </summary>
    //public AudioSource[] audioSources; 
    //players get their own goal sound attached to them instead
	
    public int numPlayersWon = 0;
	// Use this for initialization
	void Start () {
		///know maximum number of players

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// When a player enters the goal,
    /// they are awarded first or second place
    /// their movement stops
    /// their score is updated based on timer remaining
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other) {
        // do we assume that a player triggered?
        // sure why not
        numPlayersWon++;
        AudioSource GoalSound = other.GetComponent(AudioSource);
        GoalSound.Play();

        if (other.CompareTag("Player")) {
            
            // check timeleft
            // update score based on their tag
            // cease other.movement
            // translate to "1st place" location
            // or 2ndplace
            // or nth place? how may will we have?  Ok, just 2 for now
            // Play the audiosource attached to whatever player entered
            // or 0 = player 1
            if (other.GetComponent(name).Equals("Player1")) 
                // Not sure if that works
                GameManager.playerOneFinished = true;
            
            if (other.GetComponent(name).Equals("Player2")) 
                // Not sure if that works
                GameManager.playerTwoFinished = true;
            
        }
        // when maxplayers and numplayers are the same, queue next level
        // Need to set instance gameManager.levelComplete = true;
        if (!GoalSound.isPlaying) {
            if (GameState.Instance.TwoPlayers) {
                if (numPlayersWon == 2)
                    GameState.Instance.LoadNextScene();
                //is this even necessary? I mean the else part
            } else {
                if (numPlayersWon == 1)
                    GameState.Instance.LoadNextScene();
            }
        }
    }
}
