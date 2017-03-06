using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steer2D;

public class Combat : MonoBehaviour {
	public float health;
	public GameObject Player1;
	public GameObject Player2;
	public float red;
	public float green;

	// Use this for initialization

	void Start () {
		if(this.gameObject.tag == "innerheart"){
			GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f);
		}

	}

	// Update is called once per frame
	void Update () {
		if(health < 0.0){
			if(this.gameObject.tag == "virus"){
				Player2.GetComponent<Player>().units -= 1;
				if(GetComponent<Seek2>().guarding){
					 GetComponent<Seek2>().controlpoint.GetComponent<ControlAndSpawn>().guard.Remove(gameObject);
				}
				else{
					Player2.GetComponent<Player>().swarm.Remove(gameObject);
				}
			}
			else if(this.gameObject.tag == "blood cell"){
				Player1.GetComponent<Player>().units -= 1;
				if(GetComponent<Seek2>().guarding){
					 GetComponent<Seek2>().controlpoint.GetComponent<ControlAndSpawn>().guard.Remove(gameObject);
				}
			else if (this.gameObject.tag == "innerheart"){
				//Player2 wins
				//!!!!!!!!!!!!!!!!!!!!!!!
				//!!!!!!!!!!!!!!!!!!!!!!!
				//ERIC END THE GAME HERE
				//!!!!!!!!!!!!!!!!!!!!!!!
				//!!!!!!!!!!!!!!!!!!!!!!!
			}
				else{
					Player1.GetComponent<Player>().swarm.Remove(gameObject);
				}
			}
			if(this.gameObject.tag != "innerheart"){
				Destroy(this.gameObject);
			}

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
							case "innerheart":
								if (this.gameObject.tag == "blood cell"){
									coll.gameObject.GetComponent<Combat>().health -= 5;
									if (coll.gameObject.GetComponent<Combat>().red - 0.005f > 0f){
										coll.gameObject.GetComponent<Combat>().red = coll.gameObject.GetComponent<Combat>().red -0.005f;
									}
									else{
										coll.gameObject.GetComponent<Combat>().red = 0f;
									}
									if (coll.gameObject.GetComponent<Combat>().green + 0.005f < 1f){
										coll.gameObject.GetComponent<Combat>().green = coll.gameObject.GetComponent<Combat>().green + 0.005f;
									}
									else{
										coll.gameObject.GetComponent<Combat>().green = 1f;
									}
									Debug.Log(coll.gameObject.GetComponent<SpriteRenderer>().color);
									coll.gameObject.GetComponent<SpriteRenderer>().color = new Color(coll.gameObject.GetComponent<Combat>().red, coll.gameObject.GetComponent<Combat>().green, 0f, 1f);
								}
								break;
        }

        /*if (coll.gameObject.tag == "blood cell") ;
      Destroy(this.gameObject);*/

    }
}
