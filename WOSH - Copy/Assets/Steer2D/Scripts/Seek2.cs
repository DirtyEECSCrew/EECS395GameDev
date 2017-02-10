using System;
using UnityEngine;

namespace Steer2D
{
    public class Seek2 : SteeringBehaviour
    {
        public Vector2 TargetPoint;

        void Update()
        {
            //TargetPoint = Input.mousePosition; //new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            TargetPoint = Input.mousePosition;
            TargetPoint = Camera.main.ScreenToWorldPoint(TargetPoint);
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed)
        }
        public override Vector2 GetVelocity()
        {
            return ((TargetPoint - (Vector2)transform.position).normalized * agent.MaxVelocity) - agent.CurrentVelocity;   
        }
    }
}
