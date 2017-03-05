using System;
using UnityEngine;

namespace Steer2D
{
    public class Seek2 : SteeringBehaviour
    {
        public bool guarding;
        public Vector2 TargetPoint;
        public GameObject controlpoint;

        void Update()
        {
            var player = GetComponent<Player>().playerNumber;
            if(!guarding){
            switch(player){
              case 1:
                TargetPoint = new Vector2(GameObject.Find("Player1").transform.position.x,GameObject.Find("Player1").transform.position.y);
                break;
              case 2:
                TargetPoint = new Vector2(GameObject.Find("Player2").transform.position.x,GameObject.Find("Player2").transform.position.y);
                break;
              default:
                Debug.Log("Player Not Found");
                break;
            }}
        }
        public override Vector2 GetVelocity()
        {
            return ((TargetPoint - (Vector2)transform.position).normalized * agent.MaxVelocity) - agent.CurrentVelocity;
        }
    }
}
