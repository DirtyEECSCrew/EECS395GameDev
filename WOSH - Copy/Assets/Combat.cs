using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
	public float health;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(health < 0.0){
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {

			switch(coll.gameObject.tag){
				case "blood cell":
					if(this.gameObject.tag == "virus"){
						health -= 5*(Vector2.Dot(this.gameObject.transform.up,coll.gameObject.transform.up)+1);
					}
					break;
				case "virus":
					if(this.gameObject.tag == "blood cell"){
						health -= 5*(Vector2.Dot(this.gameObject.transform.up,coll.gameObject.transform.up)+1);
					}
					break;
			}

				/*if (coll.gameObject.tag == "blood cell") ;
              Destroy(this.gameObject);*/

  }
}
