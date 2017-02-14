using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public float speed = 1f;

    public float RotationSpeed;
    public float ThrustForce;

    private float horizontal;
    private float vertical;

	private bool isWrappingX = false;
	private bool isWrappingY = false;
    private Renderer[] renderers;

    public static float curr_speed = 20f;

    void Start() {
        renderers = GetComponentsInChildren<Renderer>();
    }
	 
	void Update() {
	     /*if (Input.GetKey(KeyCode.D))
	     	transform.position += new Vector3(speed*Time.deltaTime, 0f, 0f);
	     if (Input.GetKey(KeyCode.A))
	     	transform.position -= new Vector3(speed*Time.deltaTime, 0f, 0f);
	     if (Input.GetKey(KeyCode.W))
	     	transform.position += new Vector3(0f, speed*Time.deltaTime, 0f);
	     if (Input.GetKey(KeyCode.S))
	     	transform.position -= new Vector3(0f, speed*Time.deltaTime, 0f);*/

        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        //rigidbody2D.angularVelocity = -horizontal * RotationSpeed;
        //rigidbody2D.AddForce(transform.up * vertical * ThrustForce);

        ScreenWrap();
	     	
	    }


    bool CheckRenderers()
    {
        foreach (var renderer in renderers)
        {
            // If at least one render is visible, return true
            if (renderer.isVisible)
            {
                return true;
            }
        }

        // Otherwise, the object is invisible
        return false;
    }

    void ScreenWrap()
	{
	    var isVisible = CheckRenderers();
	 
	    if(isVisible)
	    {
	        isWrappingX = false;
	        isWrappingY = false;
	        return;
	    }
	 
	    if(isWrappingX && isWrappingY) {
	        return;
	    }
	 
	    /*var cam = Camera.main;
	    var viewportPosition = cam.WorldToViewportPoint(transform.position);*/

	    Vector3 newPosition = transform.position;
	 
	    if (!isWrappingX && (newPosition.x > 1 || newPosition.x < 0))//viewportPosition
	    {
	        newPosition.x = -newPosition.x;
	        isWrappingX = true;
	    }
	 
	    if (!isWrappingY && (newPosition.y > 1 || newPosition.y < 0))
	    {
	        newPosition.y = -newPosition.y;
	        isWrappingY = true;
	    }
	 
	    transform.position = newPosition;
	}
}