using System.Collections;
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
            if (Input.GetKey(KeyCode.P))
            {
                speed = test.curr_speed*.4f;
            }
            else
            {
                speed = stored;
            }
            //Debug.Log(speed);
            transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime);
            //gameObject.transform.position += Input.GetAxis("Horizontal")* speed * Time.deltaTime;
            //gameObject.transform.position.y += Input.GetAxis("Vertical")* speed *Time.deltaTime;


        }
    }
}

