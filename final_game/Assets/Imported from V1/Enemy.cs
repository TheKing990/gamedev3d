using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float range = 5;
	public UnityEngine.AI.NavMeshAgent badMeshAgent;
	private Transform target;
	public float atkTimer = 5f;



	void Start ()
	{
		badMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update()
	{
		badMeshAgent.SetDestination (GameObject.Find ("witch").transform.position);

	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere (transform.position, range);
	}







}
