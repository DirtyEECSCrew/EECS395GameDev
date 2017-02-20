using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	public Vector2 previous;
	public float boundRadius;
	// Use this for initialization
	void Start () {
		previous = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
	}

	// Update is called once per frame
	void Update () {
		if ((this.gameObject.transform.position.x*this.gameObject.transform.position.x)+(this.gameObject.transform.position.y*this.gameObject.transform.position.y) > boundRadius*boundRadius){
			this.gameObject.transform.position = previous;
		}
		else{
			previous = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
		}
	}
}
