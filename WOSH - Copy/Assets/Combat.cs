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

        if(gameObject.tag != coll.gameObject.tag && coll.gameObject.tag != "wall" && coll.gameObject.tag != "Player1" && coll.gameObject.tag != "Player2" && coll.gameObject.tag != "ControlPoint") {

            float speed_this = GetComponent<Rigidbody2D>().velocity.magnitude;


            float speed_coll = coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;


            if (speed_coll >= speed_this)
            {
                health -= 50;
            }
        }
        /*switch(coll.gameObject.tag){
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
        }*/

        /*if (coll.gameObject.tag == "blood cell") ;
      Destroy(this.gameObject);*/

    }
}
