using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
	
	public UnityEngine.AI.NavMeshAgent navMeshAgent;
	public Animator anim;
	public float attackTimer = 3f;
	//private float turnspeed = 10f;
	private GameObject mal;
	private bool orbSwitch = true;

	public bool phase3 =false;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator> ();
		anim.Play("Armature|idle");
		mal = GameObject.Find("witch 1");





	}
	
	// Update is called once per frame
	void Update () {

		navMeshAgent.SetDestination (mal.transform.position);

		//--------------------------p1-----------------------------------------------------
		if (GameObject.Find("cage").GetComponent<malCombatScript>().boss_health>300f){
			if (attackTimer == 3f) {
			anim.CrossFade ("Armature|attack01",.1f);
			transform.Rotate(0, +30, 0);
			//Vector3 rotation = Quaternion.Lerp(transform.rotation.y,transform.rotation.y+30f,Time.deltaTime*turnSpeed).eulerAngles;
			//Debug.Log("boss health = " + GameObject.Find("cage").GetComponent<malCombatScript>().boss_health);
			attackTimer = 0f;

			} 
		/*else if((attackTimer > 3f)&&(attackTimer <4f)) {
			anim.CrossFade ("Armature|attack02",.1f);

		}
		*/



		}//-----------------------------end p1----------------------------------------



		//----------------------phase 2------------------------------------------------------
		if (GameObject.Find("cage").GetComponent<malCombatScript>().boss_health<=300f && GameObject.Find("cage").GetComponent<malCombatScript>().boss_health>150f){
			navMeshAgent.speed = 10;
			if (attackTimer == 3f) {
				
				anim.CrossFade ("Armature|attack02", .1f);
				attackTimer = 0f;
				navMeshAgent.speed = 0;
			}
		
		
		}//---------------------end phase 2, ----------------------------------------




		//------------------------------phase 3 start-----------------------
		if (GameObject.Find("cage").GetComponent<malCombatScript>().boss_health<=150f){
			phase3 = true;
			navMeshAgent.speed = 10;
			if (attackTimer == 3f) {

				if (orbSwitch == true) {
					anim.CrossFade ("Armature|attack02", .1f);
					navMeshAgent.speed = 8;
					attackTimer = 0;
					orbSwitch = false;
				}

				else if (orbSwitch == false) {
					anim.CrossFade ("Armature|attack01", .1f);
					attackTimer = 0f;
					navMeshAgent.speed = 3;
					orbSwitch = true;
				}
			}


		}





		attackTimer +=Time.deltaTime;
		if (attackTimer >= 3f) {
			attackTimer = 3f;
		}

	}














}
