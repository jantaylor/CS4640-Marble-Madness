using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	
    public int numPlayersWon = 0;
	// Use this for initialization
	void Start () {
		
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
    void OnTriggerExit(Collider other)
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


        }
        //do same 
    }
}
