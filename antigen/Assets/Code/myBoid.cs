using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBoid : MonoBehaviour {
    public List<myBoid> flock = new List<myBoid>();
    public float speed = 2f;

    private Vector3 separationVector = new Vector3(0, 0, 0);
    private Vector3 alignmentVector = new Vector3(0, 0, 0);
    private Vector3 cohesionVector = new Vector3(0, 0, 0);

    void Start() {
        initialise_positions();
        GetFlock();
    }
	 
	void Update() {
        //draw_boids();
        //move_all_boids_to_new_positions();


        }



    void GetFlock()
    {
        myBoid[] boids = FindObjectsOfType(typeof(myBoid)) as myBoid[];

        // add all boids except for self
        for (int i = 0; i < boids.Length; i++)
        {
            int id1 = boids[i].GetInstanceID();
            myBoid boid = gameObject.GetComponent(typeof(myBoid)) as myBoid;
            int id2 = boid.GetInstanceID();

            if (id1 != id2)
            {
                flock.Add(boids[i]);
                //print ( "me=" + gameObject.name + " adding=" + boids[i].name );
            }
        }
    }

    public void initialise_positions()
    {
        return;
    }


    public void draw_boids()
    {
        return;
    }
    
    public void move_all_boids_to_new_positions()
    {
        return;
    }

}