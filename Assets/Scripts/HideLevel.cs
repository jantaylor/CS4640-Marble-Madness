using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLevel : MonoBehaviour {

    public GameObject platform;

    private void OnTriggerEnter(Collider other) {
        // Hide/disable the parent object when the player hits this.
        // Of course this won't work in 2 player mode due to one player may remain on the platform (screen cheaters)
        platform.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.Instance.playerRespawn) {
            platform.gameObject.SetActive(true);
            GameState.Instance.playerRespawn = false;
        }
	}
}
