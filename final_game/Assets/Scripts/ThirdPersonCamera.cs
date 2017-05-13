using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public float distanceAway = 3.0f;
    public float distanceUp = 0.5f;
    public float smooth = 5.0f;

    //Smoothing and Damping
    private Vector3 velocityCamSmooth = Vector3.zero;
    private float camSmoothDampTime = 0.1f;

    //Global Private Variables
    private Transform target;
    private Vector3 dcp; // Desired Camera Position
    private Vector3 lookDir;
    private Vector3 offset = new Vector3(0f, 1.5f, 0f);

    private float horizontal;
    private float vertical;
	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("CameraTarget").transform;
	}

    void LateUpdate () {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 behindTarget = target.position + target.up * distanceUp - target.forward * distanceAway;
        if (Input.GetButtonDown("RSClick")){
            transform.position = Vector3.Lerp(transform.position, behindTarget, 3f);
        }
        Vector3 characterOffset = target.transform.position + offset;
        lookDir = characterOffset - this.transform.position;
        lookDir.y = 0f;
        lookDir.Normalize();
        dcp = target.position + target.up * distanceUp - lookDir * distanceAway;

       
       
        Debug.DrawLine(this.transform.position, lookDir, Color.green);


        //.DrawLine(target.position, Vector3.up * distanceUp, Color.red);
       // Debug.DrawLine(target.position, -1 * Vector3.forward * distanceAway, Color.blue);
        Debug.DrawLine(target.position, dcp, Color.magenta);

        SmoothPosition(this.transform.position, dcp);
        transform.LookAt(target);
	}

    private void SmoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime * smooth);
    }
    
    bool targetIsMoving()
    {

        if (horizontal > 0.19f || vertical > 0.19f)
            return true;
        else
            return false;
    }
}
