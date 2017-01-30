using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarms : MonoBehaviour {

	public GameObject target;
	public float moveSpeed = 5;
	public float rotationSpeed =5;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody2D>();
		target = GameObject.Find("Mouse");

	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.transform.position-transform.position),rotationSpeed*Time.deltaTime);
		transform.position += transform.forward*Time.deltaTime;

	}
}
