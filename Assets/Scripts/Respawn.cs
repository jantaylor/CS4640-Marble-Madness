using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Transform respawnPoint = null;
    public GameObject player1;
    

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player1.transform.position = respawnPoint.position;
    }
}
