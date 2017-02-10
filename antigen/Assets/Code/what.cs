using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control : MonoBehaviour
{

    public static Vector3 centreOfMass = Vector3.zero;
    public static Vector3 globalVelocity = Vector3.zero;
    public GameObject COMSphere;

    public GameObject controlBall;

    public bool use2d = false;

    public static int numberOfnewBoids = 300;
    public Text newBoidCountReporter;

    public Slider centreOfMassController;
    public Slider distanceController;
    public Slider velocityController;
    public Slider controLBallController;

    public static GameObject physnewBoid;
    public GameObject newBoidBody;

    public newBoid[] newBoids;

    Vector3 tempVector;

    float maxProxyValue = 1;

    Vector3 c1;
    Vector3 c2;
    Vector3 c3;
    Vector3 ballpos;

    public static float maxDistanceFromOrigin = 50f;

    public float sensitivity = 10;
    public float heightRot = 0;
    public float yRot = 0;
    float rotIntmd;
    float camDistance = 30;
    Vector3 centreOfCam = Vector3.zero;
    public Toggle centreOnSwarm;

    void Start()
    {
        physnewBoid = newBoidBody;

        //Create the newBoid array
        newBoids = new newBoid[numberOfnewBoids];
        for (int b = 0; b < numberOfnewBoids; b++)
        {
            newBoids[b] = new newBoid(b);
            //print("Created a newBoid.");
        }
        newBoidCountReporter.text = "newBoids: " + numberOfnewBoids;
    }

    // Update is called once per frame
    void Update()
    {
        //Update control ball
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = camDistance;
            Ray r = Camera.main.ScreenPointToRay(mousePos);
            //ballpos += Camera.main.transform.forward * camDistance;

            controlBall.transform.position = r.origin + r.direction * camDistance;
        }

        //Get camera position
        if (Input.GetMouseButton(1))
        {
            yRot += Input.GetAxis("Mouse X") * sensitivity / 100;
            heightRot -= Input.GetAxis("Mouse Y") * sensitivity / 100;

            if (yRot > Mathf.PI * 2)
            {
                yRot = 0;
            }
            else
            {
                if (yRot < Mathf.PI * -2)
                {
                    yRot = Mathf.PI * -2;
                }
            }

            if (heightRot > Mathf.PI / 2)
            {
                heightRot = Mathf.PI / 2;
            }
            else
            {
                if (heightRot < -Mathf.PI / 2)
                {
                    heightRot = -Mathf.PI / 2;
                }
            }
        }
        //Change distance
        camDistance += Input.GetAxis("Mouse ScrollWheel") * 10;

        float y = camDistance * Mathf.Sin(heightRot);
        rotIntmd = camDistance * Mathf.Cos(heightRot);
        float z = rotIntmd * Mathf.Cos(yRot);
        float x = rotIntmd * Mathf.Sin(yRot);
        Camera.main.transform.position = new Vector3(x, y, z);
        Camera.main.transform.LookAt(Vector3.zero, Vector3.up);


        UpdateConstants();
        COMSphere.transform.position = centreOfMass;

        //Update all newBoids
        for (int b = 0; b < numberOfnewBoids; b++)
        {
            c1 = PercievedCentreOfMass(b);
            c2 = PercievedVelocity(b);
            c3 = newBoidRepulsion(b);
            float intensity = c3.magnitude;
            if (intensity > maxProxyValue) maxProxyValue = intensity;


            newBoids[b].SetColorIntensity(1 - (intensity / maxProxyValue));

            newBoids[b].velocity = newBoids[b].velocity + c1 + c2 + c3 + distanceController.value * FollowBall(b);
            newBoids[b].UpdatenewBoid(use2d);
        }
    }


    void UpdateConstants()
    {
        //Calculate global centre of mass
        tempVector = Vector3.zero;
        for (int j = 0; j < numberOfnewBoids; j++)
        {
            tempVector += newBoids[j].position;
        }
        centreOfMass = tempVector / numberOfnewBoids;
        tempVector = Vector3.zero;

        //Calculate global velocity
        for (int b = 0; b < numberOfnewBoids; b++)
        {
            tempVector += newBoids[b].velocity;
        }
        tempVector = tempVector / numberOfnewBoids;
        globalVelocity = tempVector;
    }



    public Vector3 FollowBall(int newBoidID)
    {
        //Calculate vector from newBoid to control ball
        return (controlBall.transform.position - newBoids[newBoidID].position) * controLBallController.value * reverseSigmoid(Vector3.Distance(newBoids[newBoidID].position, controlBall.transform.position));
    }

    public Vector3 newBoidRepulsion(int newBoidID)
    {
        Vector3 returnVect = Vector3.zero;

        for (int b = 0; b < numberOfnewBoids; b++)
        {
            if ((b != newBoidID) && ((newBoids[newBoidID].position - newBoids[b].position).magnitude < distanceController.value))
            {
                returnVect = returnVect - (newBoids[b].position - newBoids[newBoidID].position);
            }
        }
        return returnVect;
    }

    public Vector3 PercievedCentreOfMass(int newBoidID)
    {
        Vector3 COMP = (centreOfMass - (newBoids[newBoidID].position / numberOfnewBoids));
        return (COMP - newBoids[newBoidID].position) * centreOfMassController.value;
    }

    public Vector3 PercievedVelocity(int newBoidID)
    {
        return velocityController.value * (globalVelocity - (newBoids[newBoidID].velocity / numberOfnewBoids));
    }


    float reverseSigmoid(float x)
    {
        return 1 / Mathf.Exp(x / Mathf.Abs(distanceController.value));
    }
}


public class newBoid
{

    Vector3 currentVelocity;

    GameObject body;
    public Vector3 velocity = Vector3.zero;
    public int ID;
    Color originalColor;
    Renderer r;

    public newBoid(int newBoidID)
    {
        body = (GameObject)Object.Instantiate(Control.physnewBoid, RandomVector(30), Quaternion.identity);

        r = body.GetComponent<Renderer>();
        originalColor = r.material.color;
        ID = newBoidID;
        body.name = "newBoid " + ID;
        velocity = RandomVector(2f);
        MonoBehaviour.print("newBoid " + ID + " created.");
    }

    // Use this for initialization
    void Start()
    {

    }

    public void SetColorIntensity(float amount)
    {
        float intensity = amount;
        r.material.color = new Color(originalColor.r * intensity, originalColor.g * intensity, originalColor.b * intensity, 1);
    }

    //Scabbage wuz here
    public void UpdatenewBoid(bool Use2D)
    {
        //Add the velocity * time elapsed to the position
        currentVelocity = Vector3.Lerp(currentVelocity, velocity, Time.deltaTime * 4);
        body.transform.position += currentVelocity * Time.deltaTime;



        if (velocity.magnitude > 2)
        {
            velocity = velocity.normalized * 2;
        }

        if (position.magnitude > Control.maxDistanceFromOrigin) body.transform.position = -body.transform.position.normalized * Control.maxDistanceFromOrigin;

        Debug.DrawLine(body.transform.position, body.transform.position + velocity, Color.red);

        if (Use2D)
        {
            Vector3 pos = body.transform.position;
            pos.y = 0;
            body.transform.position = pos;
        }
    }



    public Vector3 position
    {
        get
        {
            return body.transform.position;
        }
    }


    Vector3 RandomVector(float minMax)
    {
        return new Vector3(Random.Range(-minMax, minMax), Random.Range(-minMax, minMax), Random.Range(-minMax, minMax));
    }
}