using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		//speed = 5f;
	}

	// Update is called once per frame
	void Update () {
			
			Debug.Log(speed);
			transform.position = new Vector2(transform.position.x+Input.GetAxis("Horizontal")* speed * Time.deltaTime, transform.position.y+Input.GetAxis("Vertical")* speed *Time.deltaTime);
			//gameObject.transform.position += Input.GetAxis("Horizontal")* speed * Time.deltaTime;
			//gameObject.transform.position.y += Input.GetAxis("Vertical")* speed *Time.deltaTime;
	}
}
