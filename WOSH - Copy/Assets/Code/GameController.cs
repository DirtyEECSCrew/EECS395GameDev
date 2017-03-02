using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GUIText timerText;
    //public GUIText livesText;
    public GUIText gameOverText;
    public GUIText restartText;
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
            GameOver();
        }
        UpdateText();
    }

    void UpdateText()
    {
        timerText.text = "Time: " + count;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
