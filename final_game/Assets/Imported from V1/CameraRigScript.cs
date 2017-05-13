using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigScript : MonoBehaviour {

	Transform playerPosition;
	public GameObject player;
	private Transform location;
	// Use this for initialization
	void Start () {
		playerPosition = player.transform;
		

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerPosition.position;

	}
}
