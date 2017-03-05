using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int playerNumber;
	public int units;
	public List<GameObject> swarm;
	// Use this for initialization
	void Start () {
		if(gameObject.tag == "Player1" || gameObject.tag == "Player2"){
			swarm = new List<GameObject>();
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
