using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLevel : MonoBehaviour {

    public GameObject platform;

    //void OnTriggerEnter(Collider other) {
        // Hide/disable the parent object when the player hits this.
        // Of course this won't work in 2 player mode due to one player may remain on the platform (screen cheaters)
        //platform.gameObject.setEnabled(false);
    //}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
