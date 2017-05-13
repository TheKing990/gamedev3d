using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombatScript : MonoBehaviour {

	public float mal_health = 200f;
	public Animator anim;
	public GameObject mal;
	public GameObject boss;
	public bool alreadyHit = false;
	public Light damagedLight;


	void OnTriggerEnter(Collider other){
		alreadyHit = false;
		boss = GameObject.Find ("Enemy");
		anim = boss.GetComponent<Animator> ();
		if (alreadyHit == false) {
			if(other.tag == "whiteOrb"){
				Debug.Log (gameObject.name + " hit by " + other.gameObject.name);
				damagedLight.range = .1f;
				alreadyHit = true;
				mal_health -= 5;
				Debug.Log ("Player Health = " + mal_health);
			}

			if(other.tag == "redOrb"){
				Debug.Log (gameObject.name + " hit by " + other.gameObject.name);
				damagedLight.range = 0.1f;
				alreadyHit = true;
				mal_health -= 2;
				Debug.Log ("Player Health = " + mal_health);
				Destroy (other);
			}

			if(other.tag == "blueOrb"){
				Debug.Log (gameObject.name + " hit by " + other.gameObject.name);
				damagedLight.range = .1f;
				alreadyHit = true;
				mal_health -= 2;
				Debug.Log ("Player Health = " + mal_health);
				Destroy (other);
			}
		
		}damagedLight.range = 0.85f;





	}















}
