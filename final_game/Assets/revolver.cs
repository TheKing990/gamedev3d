using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolver : MonoBehaviour {

	public GameObject redOrbPrefab;
	public GameObject magicOrbPrefab;
	public GameObject whiteOrbPrefab;
	public GameObject boss;
	public Transform firePoint;
	public float reloadTime = 3f;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = boss.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		//phase1 & 2
		if (GameObject.Find ("Enemy").GetComponent<BossScript> ().phase3 == false) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("StarAttack") == true && reloadTime == 3f) {
				ShootWhiteOrb ();
				reloadTime = 0f;
			}



			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("SlashAttack") == true && reloadTime == 3f) {
				ShootRedOrb ();
				reloadTime = 0f;
			}
		}

		if (GameObject.Find ("Enemy").GetComponent<BossScript> ().phase3 == true && reloadTime == 3f) {

			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("SlashAttack") == true && reloadTime == 3f) {
				ShootRedOrb ();
				reloadTime = 0f;
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("StarAttack") == true && reloadTime == 3f) {
				ShootBlueOrb ();
				reloadTime = 0f;
			}



		}







		reloadTime += Time.deltaTime;
		if (reloadTime > 3f) {
			reloadTime = 3;
		}
			

	}




	void ShootWhiteOrb()
	{
		//Vector3 dir = firePoint.rotation;
		GameObject whiteOrbGO = (GameObject)Instantiate (whiteOrbPrefab, firePoint.position, Quaternion.Euler(firePoint.localRotation.x,0f, 0f));
		//WhiteOrbScript whiteOrb = whiteOrbGO.GetComponent<WhiteOrbScript> (); 
	}



	void ShootRedOrb()
	{
		//Vector3 dir = firePoint.rotation;
		GameObject RedOrbGO = (GameObject)Instantiate (redOrbPrefab, firePoint.position, Quaternion.Euler(firePoint.localRotation.x,0f, 0f));
		//WhiteOrbScript whiteOrb = whiteOrbGO.GetComponent<WhiteOrbScript> (); 
	}

	void ShootBlueOrb()
	{
		//Vector3 dir = firePoint.rotation;
		GameObject BluedOrbGO = (GameObject)Instantiate (magicOrbPrefab, firePoint.position, Quaternion.Euler(firePoint.localRotation.x,0f, 0f));
		//WhiteOrbScript whiteOrb = whiteOrbGO.GetComponent<WhiteOrbScript> (); 
	}
}
