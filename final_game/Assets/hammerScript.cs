using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){


			if(other.tag == "whiteOrb"){
				Debug.Log (gameObject.name + " hammered  " + other.gameObject.name);
				Destroy (other);
			}

			if(other.tag == "redOrb"){
			Debug.Log (gameObject.name + " hammered  " + other.gameObject.name);
				Destroy (other);
			}

			if(other.tag == "blueOrb"){
			Debug.Log (gameObject.name + " hammered  " + other.gameObject.name);
			Destroy (other);
			}
			

		
		}


}

