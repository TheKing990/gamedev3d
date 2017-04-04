using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour {
	public float range = 5;
	public UnityEngine.NavMeshAgent badMeshAgent;
	private Transform target;


	void Start ()
	{
		badMeshAgent = GetComponent<UnityEngine.NavMeshAgent>();
	}
	
	void Update()
	{
		badMeshAgent.SetDestination (GameObject.Find ("GoodGuy").transform.position);
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere (transform.position, range);
	}







}
