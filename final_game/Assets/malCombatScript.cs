using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malCombatScript : MonoBehaviour {


	public float boss_health = 400f;
	public Animator anim;
	public GameObject mal;
	public GameObject boss;
	public bool alreadyHit = false;
	public Light hitLight;




	void OnTriggerEnter(Collider other){
		alreadyHit = false; //trying to get the check tojust happen once vs mulitple times per frame
		mal = GameObject.Find ("witch 1");
		anim = mal.GetComponent<Animator> ();
		if (alreadyHit == false) {
			if (other.tag == "hammer") {
				if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("hammer_attack") == true) {
					Debug.Log (gameObject.name + " hit by " + other.gameObject.name);
					hitLight.color = Color.red;
					alreadyHit = true;
					//---------------------change to -5---------------
					boss_health -= 7;
					Debug.Log ("Boss Health = " + boss_health);

				}
			}

			if (other.tag == "swords") {
				if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") == true) {
					Debug.Log (gameObject.name + " hit by " + other.gameObject.name);
					hitLight.color = Color.red;
					alreadyHit = true;
					boss_health -= 10;
					Debug.Log ("Boss Health = " + boss_health);
				}
			}
		}

	}


	void OnTriggerExit(Collider other){
		if ((other.tag == "swords") || (other.tag == "hammer")) {
			hitLight.color = Color.white;
		}
	}







}







