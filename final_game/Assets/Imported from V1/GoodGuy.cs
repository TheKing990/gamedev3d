using UnityEngine;
using System.Collections;

public class GoodGuy : MonoBehaviour {
	
	public UnityEngine.AI.NavMeshAgent navMeshAgent;
	public Animator anim;
	//public float powerUpTime = 10f;
	//public float powerUpCooldown = 30f;

	public int playerHealth = 100;
	//public float attackCooldown= .5f;
	public float stanceCooldown = 2f;
	public float stanceDamage =1f;
	public float distance = 7f;
	public float turnspeed = 5f;
	public Camera cam;
	public Transform target;
	public float verticalDistance = 50f;
	public Light lightStance;
	private bool shiftRight=false;
	public float comboTimer =1.5f;


	public enum StanceType{
		instinct 	= 0,
		mystic 		= 1,
		valor		= 2
	};

	public StanceType current_stance = StanceType.mystic;
	public StanceType right_stance = StanceType.valor;
	public StanceType left_stance = StanceType.instinct;
	public StanceType temp;

	public GameObject swordL;
	public GameObject swordR;
	public GameObject hammer;
	public GameObject hammerCollider;

	public GameObject hat;
	public GameObject coat;
	public GameObject hips;
	public GameObject legs;

	public Texture hatTexture; 
	public Texture coatTexture;
	public Texture hipsTexture;
	public Texture legsTexture;





	void Start () {
		

		//rend = GetComponent<Renderer> ();
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		lightStance.color = Color.cyan;
		anim = GetComponent<Animator> ();
		//anim.SetInteger (comboCounter, 0);
		//currentRotation = transform.rotation;
		hammer = GameObject.Find("hammer_final_lowPoly");
		hammerCollider = GameObject.Find("hammer");
		swordL = GameObject.Find("sword.L");
		swordR = GameObject.Find("sword.R");

		hat = GameObject.Find ("hat");
		coat= GameObject.Find ("coat");
		hips= GameObject.Find ("hips and upper legs");
		legs= GameObject.Find ("boots");

		hammerCollider.SetActive(false);
		hammer.SetActive(false);
		swordL.SetActive(true);
		swordR.SetActive(true);
		//rend.material.color = myColor;

		hatTexture = Resources.Load ("witch_hat_NRM") as Texture2D;
		hat.GetComponent<Renderer>().material.mainTexture = hatTexture;
		coatTexture = Resources.Load ("witch_coat_NRM") as Texture2D;
		coat.GetComponent<Renderer> ().material.mainTexture = coatTexture;
		hipsTexture = Resources.Load ("witch_hips_NRM")as Texture2D;
		hips.GetComponent<Renderer> ().material.mainTexture = hipsTexture;
		legsTexture = Resources.Load ("witch_legs_NRM")as Texture2D;
		legs.GetComponent<Renderer> ().material.mainTexture = legsTexture;



	}

	void Update () {
		

		if(Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
			player_walk ();

		}

		else if(!Input.GetKey(KeyCode.W) &&!Input.GetKey (KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey (KeyCode.D)) {
			player_idle();

		}


		if(Input.GetKey(KeyCode.W) && (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true)){
			transform.position = transform.position + cam.transform.forward * distance * Time.deltaTime;
			Vector3 dir = target.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation (dir);
			Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);


		}

		if(Input.GetKey(KeyCode.D) && (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true)){
			transform.position = transform.position + cam.transform.right * distance * Time.deltaTime;
			Vector3 dir = target.position- transform.position ;
			Quaternion lookRotation = Quaternion.LookRotation(dir);
			lookRotation *=Quaternion.Euler(0,90,0);
			Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y , 0f);

		}

		if(Input.GetKey(KeyCode.A) && (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true)){
			transform.position = transform.position + cam.transform.right * -distance * Time.deltaTime;
			Vector3 dir = target.position- transform.position ;
			Quaternion lookRotation = Quaternion.LookRotation (dir);
			lookRotation *=Quaternion.Euler(0,-90,0);
			Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		}

		if(Input.GetKey(KeyCode.S)&&(anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true)){
			transform.position = transform.position + cam.transform.forward * -distance * Time.deltaTime;
			Vector3 dir = target.position- transform.position ;
			Quaternion lookRotation = Quaternion.LookRotation(-dir);
			Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		}


		if(Input.GetKeyDown(KeyCode.Space)){
			//print ("jump");

		}


		if(Input.GetKeyDown(KeyCode.J)){
			//if (attackCooldown == .5f) {
				player_attack ();
				//attackCooldown = 0f;
			//} 
				

			


		}


		if(Input.GetKeyDown(KeyCode.K)){
			//print ("leftshift");
			shiftRight= true;
			stanceShift(shiftRight);

		}

		if(Input.GetKeyDown(KeyCode.L)){
			//print ("rightshift");
			shiftRight= false;
			stanceShift(shiftRight);
		}




		stanceCooldown += Time.deltaTime;
		if (stanceCooldown >= 2f) {
		stanceCooldown = 2f;
		}


		if ((anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_attack to idle transition") == true)||(anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_attack to idle transition") == true )) {
			anim.SetInteger ("comboCount", 1);
		}



	}



	void stanceShift(bool shiftRight){
		if (stanceCooldown == 2f) {
			



		if (shiftRight == true) {
			
			temp = current_stance;
			current_stance = right_stance;
			//right_stance = left_stance;
			right_stance = temp;
			left_stance = temp;

			
			/*
			 * tempStance = currentStance
			 * currentStance = rightStance
			 * rightStance = leftStance
			 * leftStance = tempStance
			 */

		} else {

			temp = current_stance;
			//current_stance = left_stance;
			current_stance = right_stance;
			//left_stance = right_stance;
			left_stance= temp;
			right_stance = temp;
			/*
			 * tempStance = currentStance
			 * currentStance = leftStance
			 * leftStance = rightStance
			 * rightStance = tempStance
			 * 
			 */


		}
		
		switch (current_stance) {
		case StanceType.mystic:
			hatTexture = Resources.Load ("witch_hat_NRM") as Texture2D;
			hat.GetComponent<Renderer>().material.mainTexture = hatTexture;
			coatTexture = Resources.Load ("witch_coat_NRM") as Texture2D;
			coat.GetComponent<Renderer>().material.mainTexture = coatTexture;
			hipsTexture = Resources.Load ("witch_hips_NRM")as Texture2D;
			hips.GetComponent<Renderer> ().material.mainTexture = hipsTexture;
			legsTexture = Resources.Load ("witch_legs_NRM")as Texture2D;
			legs.GetComponent<Renderer> ().material.mainTexture = legsTexture;

			

			hammerCollider.SetActive(false);
			hammer.SetActive(false);
			swordL.SetActive(true);
			swordR.SetActive(true);
			//print ("mystic");
			lightStance.color = Color.cyan;
			stanceDamage = 1f;
			distance =11f;
			//anim.Play ("dualSwords_idle", -1, 0f);
			

			break;

		case StanceType.instinct:
			hammerCollider.SetActive(false);
			hammer.SetActive(false);
			swordL.SetActive(false);
			swordR.SetActive(false);
			//print ("instinct");
			lightStance.color = Color.yellow;
			stanceDamage = .5f;
			distance = 6f;
			break;

		case StanceType.valor:
			//print ("valor");
			hatTexture = Resources.Load ("witch_hat_DIFF") as Texture2D;
			hat.GetComponent<Renderer>().material.mainTexture = hatTexture;
			coatTexture = Resources.Load ("witch_coat_DIFF") as Texture2D;
			coat.GetComponent<Renderer>().material.mainTexture = coatTexture;
			hipsTexture = Resources.Load ("witch_hips_DIFF")as Texture2D;
			hips.GetComponent<Renderer> ().material.mainTexture = hipsTexture;
			legsTexture = Resources.Load ("witch_legs_DIFF")as Texture2D;
			legs.GetComponent<Renderer> ().material.mainTexture = legsTexture;

			hammerCollider.SetActive(true);
			hammer.SetActive(true);
			swordL.SetActive(false);
			swordR.SetActive(false);
			lightStance.color = Color.red;
			stanceDamage = 2.5f;
			distance = 6f;
			//anim.Play ("hammer_idle", -1, 0f);
			
			break;


		}

			anim.SetInteger ("comboCount", 1);
			stanceCooldown = 0f;
		} 


	}





	void player_attack()
	{
		switch (current_stance){
		case StanceType.mystic:
			if ((anim.GetInteger ("comboCount") == 1) && (anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_attack01") != true) && (anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_idle to attack transition") != true)){
				anim.Play ("dualSwords_idle to attack transition", 0, 0f);
			} 
			if ((anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_attack01") == true)|| (anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_idle to attack transition")==true)) {
				anim.SetInteger ("comboCount", 2);
			} 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("dualSwords_attack02") == true) {
				anim.SetInteger ("comboCount", 3);
			}


			//print ("mystic attack");

			//anim.
			break;

		case StanceType.instinct:
			anim.Play("hammer_attack02",0,.5f);


			//anim.Play("Armature|hammer_attackString01",-1,.5f);
			//print ("instinct attack");
			break;

		case StanceType.valor:
			//anim.Play("dualSwords_attackString",-1,0f);
			if ((anim.GetInteger ("comboCount") == 1)  && (anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_attack01") != true) && (anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_idle-attack transition") != true)){
				anim.Play("hammer_idle-attack transition",0,0f);
			} 
			if ((anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_attack01") == true)|| (anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_idle-attack transition")==true)) {
				anim.SetInteger ("comboCount", 2);
			} 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("hammer_attack02") == true) {
				anim.SetInteger ("comboCount", 3);
			}



			//print ("valor attack");
			break;



		}





	}





	void player_walk()
	{
		switch (current_stance) {
		case StanceType.mystic:
			//if(anim.GetCurrentAnimatorStateInfo(0).length==0)
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true) {
				anim.CrossFade ("dualSwords_walk", .05f);
			}
			//}

			//print ("mystic attack");
			break;

		case StanceType.instinct:
			if ( (anim.GetCurrentAnimatorStateInfo (0).IsTag ("hammer_attack") != true) || (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true) ) {
				anim.CrossFade ("dualSwords_walk", .1f);
			}
			//print ("instinct attack");
			break;

		case StanceType.valor:
			//anim.Play("dualSwords_attackString",-1,0f);
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("hammer_attack") != true) {
				anim.CrossFade ("hammer_walk", .05f);
			}

			//print ("valor attack");
			break;
		}
	}




	void player_idle()
	{
		
		switch (current_stance) {
		case StanceType.mystic:
			//if(anim.GetCurrentAnimatorStateInfo(0).length==0)
			//{
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("sword_attack") != true) {
				anim.CrossFade ("dualSwords_idle", .05f);
			}
			//}

			//print ("mystic attack");
			break;

		case StanceType.instinct:
			//anim.Play ("dualSwords_attackString", -1, 0f);
			//anim.Play("Armature|hammer_attackString01",-1,.5f);
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("hammer_attack") != true) {
				anim.CrossFade ("dualSwords_idle", .05f);
			}
			//print ("instinct attack");
			break;

		case StanceType.valor:
			//anim.Play("dualSwords_attackString",-1,0f);
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("hammer_attack") != true) {
				anim.CrossFade ("hammer_idle", .05f);
			}

			//print ("valor attack");
			break;
		}
	}



}



/*
//TODO: 
 REMOVE YELLOW
 PROJECTILE ATTACK
 COMBO TIMINGS

 CAMERA TUNING
 MOVEMENT TUNING
 
 SPHERE BOSS
 MULTISWORD ATTACKS
 ATTACK PATTERNS
  
 UI
 MAIN MENU
 PLAYER & BOSS HEALTH
  
 ATTACK COLLISIONS
  

 
 */