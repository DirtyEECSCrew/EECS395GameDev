using System;
using UnityEngine;

namespace Steer2D
{
    public class Seek2 : SteeringBehaviour
    {
        public Vector2 TargetPoint;

        void Update()
        {
            var player = GetComponent<Player>().playerNumber;
            TargetPoint = new Vector2(GameObject.Find("Player1").transform.position.x,GameObject.Find("Player1").transform.position.y);
        }
        public override Vector2 GetVelocity()
        {
            return ((TargetPoint - (Vector2)transform.position).normalized * agent.MaxVelocity) - agent.CurrentVelocity;
        }
    }
}
