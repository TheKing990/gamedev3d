using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrbScript : MonoBehaviour {

	public float speed = .5f;
	public float maxDist= 30f;
	public float currentDist= 0f;
	public GameObject boss;
	public GameObject mal;
	public Transform target;
	// Use this for initialization
	void Start () {
		boss = GameObject.Find("boss");
		mal = GameObject.Find ("witch 1");
		target = mal.transform;
	}

	// Update is called once per frame
	void Update () {
		float distanceThisFrame = speed * Time.deltaTime;
		if (currentDist > maxDist) {
			Destroy (gameObject);
		}

		//Vector3 dir = transform.localRotation.eulerAngles.normalized;
		if (currentDist <= 10) {
			speed = 10;
			Vector3 dir = boss.transform.position - transform.position;
			transform.Translate (-dir.normalized * distanceThisFrame, Space.World);
		}

		if(currentDist>20){
			Vector3 dir = target.position - transform.position;
			speed = 2f;
			if (dir.magnitude <= distanceThisFrame) 
			{
				HitTarget();
				return;
			}

			transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		}




		currentDist += distanceThisFrame;


	}





	void HitTarget()
	{	
		Destroy(gameObject);
		//Debug.Log ("hit!");
	}





}
