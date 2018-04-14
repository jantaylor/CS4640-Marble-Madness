using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour {
	
    /// <summary>
    /// The audio source.
    /// </summary>
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        
        audioSource = GetComponent<AudioSource>();
	}
	
	/// <summary>
    /// Raises the trigger enter event.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
            audioSource.Play();
    }
}
