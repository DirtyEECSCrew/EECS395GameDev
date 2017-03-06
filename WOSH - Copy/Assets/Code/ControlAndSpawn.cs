using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Steer2D;

public class ControlAndSpawn : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Antibody;
    public GameObject Virus;       //Public variable to store a reference to instantiating
    public float SpawnRate;
    public string controlled;
    public float CaptureRate;
    public int UnitCap;
    public float radius;
    public List<GameObject> guard;
    private string capturing;
    private bool contested;
    private float CaptureTimer;
    private float Timer;
    private float ContestedTimer;

    // Use this for initialization
    void Start ()
    {
        Timer = Time.time + SpawnRate;
        contested = false;

        CaptureTimer = CaptureRate;

    }

    //Update is called each frame
    internal void Update ()
    {

            switch (controlled)
            {
                case "blood cell":
                    if (Mathf.Pow(Player1.transform.position.x - gameObject.transform.position.x,2)+Mathf.Pow(Player1.transform.position.y - gameObject.transform.position.y,2) < radius*radius){
                      if(Input.GetKeyDown("joystick 1 button 16")){
                        if(Player1.GetComponent<Player>().swarm.Count > 0){
                          var temp = Player1.GetComponent<Player>().swarm[0];
                          Player1.GetComponent<Player>().swarm.RemoveAt(0);
                          temp.GetComponent<Seek2>().guarding = true;
                          temp.GetComponent<Seek2>().controlpoint = gameObject;
                          temp.GetComponent<Seek2>().TargetPoint = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
                          guard.Add(temp);
                        }
                      }
                      if (Input.GetKeyDown("joystick 1 button 17")){

                        if(guard.Count > 0){
                          var temp = guard[0];
                          guard.RemoveAt(0);
                          temp.GetComponent<Seek2>().guarding = false;
                          temp.GetComponent<Seek2>().controlpoint = null;
                          Player1.GetComponent<Player>().swarm.Add(temp);
                        }
                      }

                    }
                    var  units = Player1.GetComponent<Player>().units;

                    if (Timer < Time.time && units < UnitCap)
                    {

                        Player1.GetComponent<Player>().swarm.Add(Instantiate(Antibody, transform.position, Quaternion.identity));
                        Player1.GetComponent<Player>().units += 1;
                        Timer = Time.time + SpawnRate;
                    }

                    break;
                case "virus":
                    if (Mathf.Pow(Player2.transform.position.x - gameObject.transform.position.x,2)+Mathf.Pow(Player2.transform.position.y - gameObject.transform.position.y,2) < radius*radius){
                      if(Input.GetKeyDown("joystick 2 button 16")){
                        if(Player2.GetComponent<Player>().swarm.Count > 0){
                          var temp = Player2.GetComponent<Player>().swarm[0];
                          Player2.GetComponent<Player>().swarm.RemoveAt(0);
                          temp.GetComponent<Seek2>().guarding = true;
                          temp.GetComponent<Seek2>().controlpoint = gameObject;
                          temp.GetComponent<Seek2>().TargetPoint = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
                          guard.Add(temp);
                        }
                      }
                      if (Input.GetKeyDown("joystick 2 button 17")){
                        if(guard.Count > 0){
                          var temp = guard[0];
                          guard.RemoveAt(0);
                          temp.GetComponent<Seek2>().guarding = false;
                          temp.GetComponent<Seek2>().controlpoint = null;
                          Player2.GetComponent<Player>().swarm.Add(temp);
                        }
                      }
                    }
                    units = Player2.GetComponent<Player>().units;
                    if (Timer < Time.time && units < UnitCap)
                    {

                        Player2.GetComponent<Player>().swarm.Add(Instantiate(Virus, transform.position, Quaternion.identity));
                        Player2.GetComponent<Player>().units += 1;
                        Timer = Time.time + SpawnRate;
                    }
                    break;
                default:
                    GetComponent<SpriteRenderer>().color = Color.white;
                    controlled = "None";
                    break;
            }




    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      if(coll.gameObject.tag=="Player1"){
        Debug.Log("here");
      }
        if (coll.gameObject.tag == "blood cell")
        {
            /*CaptureTimer -= Time.deltaTime;
            if (CaptureTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
                controlled = coll.gameObject.tag;

            }*/
            if(guard.Count == 0){
              GetComponent<SpriteRenderer>().color = Color.red;
              controlled = coll.gameObject.tag;
            }
        }

        if (coll.gameObject.tag == "virus")
        {
            /*CaptureTimer -= Time.deltaTime;
            if (CaptureTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
                controlled = coll.gameObject.tag;

            }*/
            if(guard.Count == 0){
              GetComponent<SpriteRenderer>().color = Color.green;
              controlled = coll.gameObject.tag;
            }
        }
        /*if (capturing != "Player1" || capturing != "Player2")
        {
            capturing = coll.gameObject.tag;
            CaptureTimer = Time.time + CaptureRate;
        }*/

        /*if(coll.gameObject.tag != capturing)
        {
            contested = true;
        }*/

        /*if (contested)
        {
            ContestedTimer += Time.deltaTime;
        }*/
    }
        void OnCollisionExit2D(Collision2D coll)
    {

        CaptureTimer = CaptureRate;
        //if (coll.gameObject.tag == capturing)
    }

}
