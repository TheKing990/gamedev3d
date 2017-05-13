using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text hpTrackerText;
	public Text bossHpText;

	void Update()
	{
		if ((GameObject.Find ("witch 1").GetComponent<BossCombatScript> ().mal_health <= 0) || (GameObject.Find ("cage").GetComponent<malCombatScript> ().boss_health <= 0)) {
			Application.LoadLevel (1);
		}


		hpTrackerText.text = "CURRENT HEALTH = " + (GameObject.Find("witch 1").GetComponent<BossCombatScript>().mal_health.ToString());
		bossHpText.text = "BOSS HITPOINTS = " + (GameObject.Find("cage").GetComponent<malCombatScript>().boss_health.ToString());

	}









}

