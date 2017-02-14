using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
  public GameObject prefab;
  public Vector2 pos = Vector2.zero;

    void Start() {
    }

	void Update() {
    if (Input.GetMouseButtonDown (0))
      {
            var mousePos = Input.mousePosition;
            //mousePos.z = 2.0f;
            var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0;
            //Instantiate(prefab, Input.mousePosition, Quaternion.identity);
            Instantiate(prefab, objectPos, Quaternion.identity);
        }
  }
}
