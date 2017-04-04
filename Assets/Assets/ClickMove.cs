using UnityEngine;

using System.Collections;

public class ClickMove : MonoBehaviour {
    public Camera cam;
    public NavMeshAgent navMeshAgent;


	void Start ()
	{
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();

	}

	void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if(Physics.Raycast(ray,out hit,100)) {
                navMeshAgent.SetDestination(hit.point);
            }

        }
	}
}
