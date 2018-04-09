using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    /// <summary>
    /// The audio source.
    /// </summary>
    public AudioSource[] audioSources;
	
    public int numPlayersWon = 0;
	// Use this for initialization
	void Start () {
		///know maximum number of players
        //audioSource = GetComponent<AudioSource>();
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
    void OnTriggerEnter(Collider other)
    {
        // do we assume that a player triggered?
        // sure why not
        numPlayersWon++;

        if (other.CompareTag("Player")) {
            // check timeleft
            // update score based on their tag
            // cease other.movement
            // translate to "1st place" location
            // or 2ndplace
            // or nth place? how may will we have?
            audioSources[0].Play();//Which player?

        }
        // when maxplayers and numplayers are the same, queue next level
    }
}
