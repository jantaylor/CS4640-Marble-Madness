using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Respawn script for if an object falls off the platform.
/// Author: Liz "Frankie" Ruttenbur
/// </summary>
public class Respawn : MonoBehaviour
{

    public GameObject respawnPoint; //respawn point for player 1
    public GameObject player2RespawnPoint; //respawn point for player 2
    public GameObject player1; //game object for player one
    public GameObject player2; //game object for player 2

   
    /// <summary>
    /// If the collider is triggered it will scan for the tags and if the tag is 
    /// player 1 or player 2 it will take the player back to the appropriate respawn point.
    /// if it doesn't have any of the tags, the game object is destroyed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player1.transform.position = respawnPoint.transform.position;
        }
        else if (other.CompareTag("Player2"))
        {
            player2.transform.position = player2RespawnPoint.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
