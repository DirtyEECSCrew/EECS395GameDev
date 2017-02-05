using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {
	private bool check;
	private Vector3 mousePosition;
  public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start () {

    }
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		/*if(check){
			var change = transform.position;
			change.x = change.x + 1f;
			transform.position = change;
			check = false;
		}
		else{
			var change = transform.position;
			change.x = change.x -10f;
			transform.position = change;
			check = true;
		}*/

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 1f);




	}
}
