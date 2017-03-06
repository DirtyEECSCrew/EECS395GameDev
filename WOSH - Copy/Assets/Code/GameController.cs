using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text timerText;
    //public GUIText livesText;
    public Text gameOverText;
    public Text restartText;
    public float count;
    private float timer;
    private bool gameOver;




    void Start()
    {
        gameOver = false;
        timer = (float)count;
        UpdateTimer();
        //UpdateLives();


    }

    private void Update()
    {
        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {

                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1;
            }
        }
        else UpdateTimer();
    }
    public bool gamestate()
    {
        return gameOver;
    }

    public float get_count()
    {
        return count;
    }

    /*void UpdateLives()
    {
        livesText.text = "Lives: " + get_count();
    }

    public void TakeLife()
    {
        count--;
        UpdateLives();
    }*/


    public void UpdateTimer()
    {
        timer -= Time.deltaTime;
        count = (int)timer;
        if (timer <= 0)
        {
            GameOver("Player1");
        }
        UpdateText();
    }

    void UpdateText()
    {
        timerText.text = "" + count;
    }

    public void GameOver(string winner)
    {
        //Debug.Log("hi");
        Time.timeScale = 0f;
        gameOverText.text = "Game Over!\n" + winner + " wins!" ;
        gameOver = true;
    }
}
