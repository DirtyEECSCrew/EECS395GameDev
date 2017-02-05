using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarms : MonoBehaviour {

	public GameObject target;
	public float moveAcceleration = 2;
	public float moveSpeed = 0;
	public float rotationSpeed =5;
	public float moveFriction = 1;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody2D>();
		target = GameObject.Find("Mouse");

	}

	// Update is called once per frame
	void Update () {
        /*GameObject[] list = FindGameObjectsWithTag("Square");

        float dist = 20f / list.Length();

        foreach (gameObject lightuser in list)
        {

        }*/




        var distance = (target.transform.position-transform.position).magnitude;
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.transform.position-transform.position),rotationSpeed*Time.deltaTime);
		Debug.Log(distance);
		moveAcceleration = distance - moveFriction;
		moveSpeed = moveSpeed + moveAcceleration *Time.deltaTime;
		if(moveSpeed < 0){
			moveSpeed = 0;
		}
		transform.position += transform.forward*Time.deltaTime* moveSpeed;

	}
}
