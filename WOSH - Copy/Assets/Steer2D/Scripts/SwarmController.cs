﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Steer2d
{
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

            if (Input.GetKey(KeyCode.P))
            {
                speed = test.curr_speed*.4f;
            }
            else
            {
                speed = stored;
            }
            //Debug.Log(speed);
            switch(player){
              case 1:
                transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime*-1);
                break;
              case 2:
                transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal2") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical2") * speed * Time.deltaTime);
                break;
            }

            //gameObject.transform.position += Input.GetAxis("Horizontal")* speed * Time.deltaTime;
            //gameObject.transform.position.y += Input.GetAxis("Vertical")* speed *Time.deltaTime;


        }
    }
}