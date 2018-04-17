using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FRANKIE RUTTENBUR
/// </summary>
public class DownTheTube : MonoBehaviour
{
    public GameObject Chute1; //respawn point for player 1
    public GameObject Chute2; //respawn point for player 2
    public Rigidbody player1; //game object for player one
    public Rigidbody player2;
    public GameObject tube; //tube object to check which tube 
    



    /// <summary>
    ///zomg it works.
    ///It's a one way chute so...
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (tube.name == "TUBE2")
        {
            if (other.CompareTag("Player"))
            {
                player1.transform.position = Chute2.transform.position;
                player1.velocity = Vector3.zero; //stops the force from moving the marble once it lands back on the platform.
            }
            else if (other.CompareTag("Player2"))
            {

                player2.transform.position = Chute2.transform.position;
                player2.velocity = Vector3.zero; //stops the force from moving the marble once it lands back on the platform.
            }
        }
        else
        {

            if (other.CompareTag("Player"))
            {
                player1.transform.position = Chute1.transform.position;
                player1.velocity = Vector3.zero; //stops the force from moving the marble once it lands back on the platform.
            }
            else if (other.CompareTag("Player2"))
            {

                player2.transform.position = Chute1.transform.position;
                player2.velocity = Vector3.zero; //stops the force from moving the marble once it lands back on the platform.
            }
        }

    }




}