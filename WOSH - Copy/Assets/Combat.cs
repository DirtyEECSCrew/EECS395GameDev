﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
	public float health;
	public GameObject Player1;
	public GameObject Player2;

	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(health < 0.0){
			if(this.gameObject.tag == "virus"){
				Player2.GetComponent<Player>().units -= 1;
			}
			if(this.gameObject.tag == "blood cell"){
				Player1.GetComponent<Player>().units -= 1;
			}
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {

				var damage = 5;
				var x = coll.gameObject.transform.position.x;
				var x1 = gameObject.transform.position.x;
				var y = coll.gameObject.transform.position.y;
				var y1 = gameObject.transform.position.y;
				var angle = Mathf.Acos(Vector3.Dot(gameObject.transform.up,new Vector3(0f,1f,0f))/(gameObject.transform.up.magnitude* new Vector3(0f,1f,0f).magnitude));
        switch(coll.gameObject.tag){
            case "blood cell":
                if(this.gameObject.tag == "virus"){
										if((((x-x1)*Mathf.Sin(angle+(Mathf.PI /2f))+((y-y1)*Mathf.Cos(angle+(Mathf.PI /2f))))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+(Mathf.PI/2f)))-((y-2)*Mathf.Sin(angle+(Mathf.PI/2f)))))){
											//target is in front
											damage = 40;
										}
										if(((x-x1)*Mathf.Sin(angle)+((y-y1)*Mathf.Cos(angle)))>Mathf.Abs(((x-x1)*Mathf.Cos(angle)-((y-2)*Mathf.Sin(angle))))){
											//target is left
											damage = 10;
										}
										if(((x-x1)*Mathf.Sin(angle+(3f*Mathf.PI /2f))+((y-y1)*Mathf.Cos(angle+(3f*Mathf.PI /2f))))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+(3f*Mathf.PI /2f))-((y-2)*Mathf.Sin(angle+(3f*Mathf.PI /2f)))))){
											//target is behind
											damage = 0;
										}
										if(((x-x1)*Mathf.Sin(angle+Mathf.PI)+((y-y1)*Mathf.Cos(angle+Mathf.PI)))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+Mathf.PI)-((y-2)*Mathf.Sin(angle+Mathf.PI))))){
											//target is right
											damage = 10;
										}
										health -= damage;

                }
                break;
            case "virus":
                if(this.gameObject.tag == "blood cell"){
									if((((x-x1)*Mathf.Sin(angle+(Mathf.PI /2f))+((y-y1)*Mathf.Cos(angle+(Mathf.PI /2f))))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+(Mathf.PI/2f)))-((y-2)*Mathf.Sin(angle+(Mathf.PI/2f)))))){
										//target is in front
										damage = 40;
									}
									if(((x-x1)*Mathf.Sin(angle)+((y-y1)*Mathf.Cos(angle)))>Mathf.Abs(((x-x1)*Mathf.Cos(angle)-((y-2)*Mathf.Sin(angle))))){
										//target is left
										damage = 10;
									}
									if(((x-x1)*Mathf.Sin(angle+(3f*Mathf.PI /2f))+((y-y1)*Mathf.Cos(angle+(3f*Mathf.PI /2f))))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+(3f*Mathf.PI /2f))-((y-2)*Mathf.Sin(angle+(3f*Mathf.PI /2f)))))){
										//target is behind
										damage = 0;
									}
									if(((x-x1)*Mathf.Sin(angle+Mathf.PI)+((y-y1)*Mathf.Cos(angle+Mathf.PI)))>Mathf.Abs(((x-x1)*Mathf.Cos(angle+Mathf.PI)-((y-2)*Mathf.Sin(angle+Mathf.PI))))){
										//target is right
										damage = 10;
									}
									health -= damage;
                }
                break;
        }

        /*if (coll.gameObject.tag == "blood cell") ;
      Destroy(this.gameObject);*/

    }
}
