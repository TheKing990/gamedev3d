using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPov : MonoBehaviour {



	[Header("Atrributes")]
	//------------upgrdadeable stuffs---------------

	public float turnspeed = 7f;



	[Header("Unity stuff")]
	//----------------------------user no change---------
	public string playerTag = "Player";
	public Transform partToRotate;
	private Transform target;





	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, .3f);
		
	}




	void UpdateTarget()
	{

		GameObject[] players = GameObject.FindGameObjectsWithTag (playerTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject player in players) 
		{
			float distanceToEnemy = Vector3.Distance (transform.position, player.transform.position);
			if (distanceToEnemy < shortestDistance) 
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy =player;
			}

		}


		if (nearestEnemy != null ) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}

	}








	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		//lockon
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		
	}





}
