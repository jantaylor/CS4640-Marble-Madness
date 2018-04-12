using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathOnCollision : MonoBehaviour {
	
    void OnTriggerEnter(Collider other) {
        string sWhoDied = other.GetComponent(name);
        string sHowTheyDied = gameObject.name;

    }
}
