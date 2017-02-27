using UnityEngine;
using System.Collections;

public class ControlAndSpawn : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;       //Public variable to store a reference to instantiating
    public float SpawnRate;
    public string controlled;
    public float CaptureRate;

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
        //GetComponent<SpriteRenderer>().color = new Color(163f, 49f, 49f, 50f);

            switch (controlled)
            {
                case "blood cell":
                    if (Timer < Time.time)
                    {
                        Instantiate(Player1, transform.position, Quaternion.identity);
                        Timer = Time.time + SpawnRate;
                    }

                    break;
                case "virus":
                    if (Timer < Time.time)
                    {
                        Instantiate(Player2, transform.position, Quaternion.identity);
                        Timer = Time.time + SpawnRate;
                    }
                    break;
                default:
                    break;
            }
        

        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("hi");
        if (coll.gameObject.tag == "blood cell")
        {
            /*CaptureTimer -= Time.deltaTime;
            if (CaptureTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
                controlled = coll.gameObject.tag;

            }*/
            GetComponent<SpriteRenderer>().color = new Color(.6f, .2f, .1f, 50f);
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
