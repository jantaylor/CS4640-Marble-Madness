using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///Marble Controller
///Liz "Frankie" Ruttenbur
/// 
/// Edits:
/// Andrew Merrell



public class MarbleController : MonoBehaviour {

    public float force = 10.0f; //adjustable force that can be changed through Unity

    private SphereCollider collide; //the marble controller for movement and physics

    private Rigidbody rb;
    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
	///Update controls the movement around of the marble.
	
    void Update()
    {
        

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * 1.2f;
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //seems like it should take accelerometer input too

        rb.AddForce(movement * speed);
    }
}
