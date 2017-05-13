using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteOrbScript : MonoBehaviour {

	public float speed = 1f;
	public float maxDist= 40f;
	public float currentDist= 0f;
	public GameObject boss;

	// Use this for initialization
	void Start () {
		boss = GameObject.Find("boss");
	}
	
	// Update is called once per frame
	void Update () {

		if (currentDist > maxDist) {
			Destroy (gameObject);
		}

		//Vector3 dir = transform.localRotation.eulerAngles.normalized;
		Vector3 dir = boss.transform.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		transform.Translate (-dir.normalized * distanceThisFrame, Space.World);
		currentDist += distanceThisFrame;

		
		
	}
}
