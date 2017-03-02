using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherSprinter : MonoBehaviour
{

    float stamina = 5, maxStamina = 5;
    public float initSpeed, sprintSpeed;
    bool isRunning;
    float cur_speed;
    SwarmController steer;

    Rect staminaRect;
    Texture2D staminaTexture;

    // Use this for initialization
    void Start()
    {
        steer = GetComponent<SwarmController>();
        //initSpeed = steer.MaxVelocity;
        //sprintSpeed = test.curr_speed;
        staminaRect = new Rect(Screen.width *6/ 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white);
        staminaTexture.Apply();
    }

    public float getSpeed()
    {
        return cur_speed;
    }
    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        steer.speed = isRunning ? sprintSpeed : initSpeed;
        cur_speed = steer.speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0.2f)
        {
            SetRunning(true);
        }
        if (Input.GetAxis("Fire2") < 0.2f)
        {
            SetRunning(false);
        }

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }
        else if (stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
    }
    private void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }
}
