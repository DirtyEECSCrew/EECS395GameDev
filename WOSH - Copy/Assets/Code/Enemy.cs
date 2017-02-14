using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  //public GameObject prefab;
  //public Vector2 pos = Vector2.zero;

    void Start() {
    }

	void Update() {


  }

  void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "blood cell") ;
              Destroy(this.gameObject);

      }
    }
