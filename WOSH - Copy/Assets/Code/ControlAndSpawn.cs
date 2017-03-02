using UnityEngine;
using System.Collections;

public class ControlAndSpawn : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Antibody;
    public GameObject Virus;       //Public variable to store a reference to instantiating
    public float SpawnRate;
    public string controlled;
    public float CaptureRate;
    public int UnitCap;
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
                    var  units = Player1.GetComponent<Player>().units;
                    
                    if (Timer < Time.time && units < UnitCap)
                    {

                        Instantiate(Antibody, transform.position, Quaternion.identity);
                        Player1.GetComponent<Player>().units += 1;
                        Timer = Time.time + SpawnRate;
                    }

                    break;
                case "virus":
                    units = Player2.GetComponent<Player>().units;
                    if (Timer < Time.time && units < UnitCap)
                    {
                        
                        Instantiate(Virus, transform.position, Quaternion.identity);
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
        
        if (coll.gameObject.tag == "blood cell")
        {
            /*CaptureTimer -= Time.deltaTime;
            if (CaptureTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
                controlled = coll.gameObject.tag;

            }*/
            
            GetComponent<SpriteRenderer>().color = Color.red;
            controlled = coll.gameObject.tag;
        }

        if (coll.gameObject.tag == "virus")
        {
            /*CaptureTimer -= Time.deltaTime;
            if (CaptureTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
                controlled = coll.gameObject.tag;

            }*/
            
            GetComponent<SpriteRenderer>().color = Color.green;
            controlled = coll.gameObject.tag;
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
