using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///Marble Controller
///Liz "Frankie" Ruttenbur
/// 
/// Edits:
/// Andrew Merrell
/// Jan Taylor



public class MarbleController : MonoBehaviour {

    public float force = 10.0f; //adjustable force that can be changed through Unity

    private SphereCollider collide; //the marble controller for movement and physics

    private Rigidbody rb;

    public float speed;

    public string horizontalCtrl = "Horizontal_P1";

    public string VerticalCtrl = "Vertical_P1";

    public GameManager gameManager;

    public bool moveable = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
	///Update controls the movement around of the marble.
	
    void Update()
    {
        

    }
    void FixedUpdate()
    {
        if (moveable) {

            float moveHorizontal = Input.GetAxis(horizontalCtrl) * 1.2f;
            float moveVertical = Input.GetAxis(VerticalCtrl);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //seems like it should take accelerometer input too

            rb.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other) {

    }
}
