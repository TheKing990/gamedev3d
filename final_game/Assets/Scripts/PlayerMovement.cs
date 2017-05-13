using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 2f;
    public float turnSpeed = 2f;
   
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        float hAxis = Input.GetAxis("LSHorizontal");
        float vAxis = Input.GetAxis("LSVertical");

        transform.Translate(hAxis * Time.deltaTime * movementSpeed, 0.0f, vAxis * Time.deltaTime * movementSpeed);
        transform.Rotate(0, turnSpeed * hAxis * Time.deltaTime, 0);
        
       
    }
}
