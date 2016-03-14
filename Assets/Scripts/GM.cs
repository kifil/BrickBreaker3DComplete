﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    //some variables for teh editor
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    //our game and UI objects
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;

    //static singleton instance of this gamemanager
    public static GM instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        //setup our GM instance
        if (instance == null)
            instance = this;
        //prevent duplicate instances
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        //create paddle and bricks
        clonePaddle = Instantiate(paddle, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    void CheckGameOver()
    {
        //win condition
        if (bricks < 1)
        {
            youWon.SetActive(true);
            //awesome slo-mo effect
            Time.timeScale = .25f;
            //reset game after a delay
            Invoke("Reset", resetDelay);
        }
        //lose condition
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        //reload current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        //blow up paddle and create particles
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        //recreate paddle
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}