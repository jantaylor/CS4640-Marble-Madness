using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject respawnPoint; //respawn point for player 1
    public GameObject player2RespawnPoint; //respawn point for player 2
    public GameObject player1; //game object for player one
    public GameObject player2; //game object for player 2

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
    /// <summary>
    /// If the collider is triggered it will scan for the tags and if the tag is 
    /// player 1 or player 2 it will take the player back to the appropriate respawn point.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            player2.transform.position = respawnPoint.transform.position;
        }
        else
        {
            player1.transform.position = player2RespawnPoint.transform.position;
        }
    }
}
