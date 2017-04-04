using UnityEngine;
using System.Collections;

public class GoodGuy : MonoBehaviour {
	public Color powerColor = Color.magenta;
	public Color normColor = Color.blue;
	public Renderer rend;
	public UnityEngine.NavMeshAgent navMeshAgent;
	public float powerUpTime = 10f;
	public float powerUpCooldown = 30f;
	public float distance = 5f;
	public Camera cam;

	void Start () {
		rend = GetComponent<Renderer> ();
		navMeshAgent = GetComponent<UnityEngine.NavMeshAgent>();
		//rend.material.color = myColor;
		
	}

	void Update () {

		if(Input.GetKey(KeyCode.W)){
			transform.position = transform.position + cam.transform.forward * distance * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.D)){
			transform.position = transform.position + cam.transform.right * distance * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.A)){
			transform.position = transform.position + cam.transform.right * -distance * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.S)){
			transform.position = transform.position + cam.transform.forward * -distance * Time.deltaTime;
		}



		if (powerUpTime == 10f && powerUpCooldown == 30f) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				rend.material.color = powerColor;
				powerUpTime = 0f;
				powerUpCooldown = 0f;
			}
		}

		if (powerUpTime < 10f) {
			powerUpTime += Time.deltaTime;
		} else {
			rend.material.color = normColor;
			powerUpTime = 10f;
		}
		

		if (powerUpCooldown < 30f) {
			powerUpCooldown += Time.deltaTime;
		} else
			powerUpCooldown = 30f;




		if (rend.material.color == Color.magenta) {
			navMeshAgent.speed = 20;
			navMeshAgent.angularSpeed = 50;
			navMeshAgent.acceleration = 600;
			distance = 30;
		} else {
			navMeshAgent.speed = 10;
			navMeshAgent.angularSpeed = 30;
			distance = 5;
		}
		
	}
}
