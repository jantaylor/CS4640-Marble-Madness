using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarble : MonoBehaviour {

    public float speed = 75;

    public float force = 100;

    public GameObject rotateAroundObject;

    void Update() {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2")) {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;

            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
