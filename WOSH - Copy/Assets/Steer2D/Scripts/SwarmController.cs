﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SwarmController : MonoBehaviour
    {
        public float speed;
        public float stored;
        // Use this for initialization
        //public GameObject prefab;
        //[RequireComponent(typeof(SteeringAgent))]

        void Start()
        {
            stored = speed;
            //speed = 5f;
        }

        // Update is called once per frame
        void Update()
        {
           var player = GetComponent<Player>().playerNumber;
            /*
            if(gameObject.tag == "Player1"){
              if (Input.GetAxis("Fire1") > 0.2f)
              {
                  speed = test.curr_speed*0.4f;

              }
              else
              {
                  speed = stored;
              }
            }
            if(gameObject.tag == "Player2"){
              if(Input.GetAxis("Fire2") > 0.2f){
                speed = test.curr_speed*0.4f;

              }
              else{
                speed = stored;
              }
            }*/
            //Debug.Log(speed);
            switch(player){
              case 1:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f && Mathf.Abs(Input.GetAxis("Vertical"))>0.2f){
                  transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime*-1);
                }
                else if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f){
                  transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + 0 * speed * Time.deltaTime*-1);
                }
                else if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f){
                  transform.position = new Vector2(transform.position.x + 0 * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime*-1);
                }
                else{
                  transform.position = new Vector2(transform.position.x + 0 * speed * Time.deltaTime, transform.position.y + 0 * speed * Time.deltaTime*-1);
                }
                break;
              case 2:
                if(Mathf.Abs(Input.GetAxis("Horizontal2")) > 0.2f && Mathf.Abs(Input.GetAxis("Vertical2"))>0.2f){
                  transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal2") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical2") * speed * Time.deltaTime);
                }
                else if(Mathf.Abs(Input.GetAxis("Horizontal2")) > 0.2f){
                  transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal2") * speed * Time.deltaTime, transform.position.y + 0 * speed * Time.deltaTime*-1);
                }
                else if(Mathf.Abs(Input.GetAxis("Vertical2"))> 0.2f){
                  transform.position = new Vector2(transform.position.x + 0 * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical2") * speed * Time.deltaTime);
                }
                else{
                  transform.position = new Vector2(transform.position.x + 0 * speed * Time.deltaTime, transform.position.y + 0 * speed * Time.deltaTime*-1);
                }
                break;
            }

            //gameObject.transform.position += Input.GetAxis("Horizontal")* speed * Time.deltaTime;
            //gameObject.transform.position.y += Input.GetAxis("Vertical")* speed *Time.deltaTime;


        }
        void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Player1"){
          Debug.Log("here1");
        }
      }
    }
