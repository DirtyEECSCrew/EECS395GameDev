using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
	}

	// Update is called once per frame
	void Update () {

	}
}
