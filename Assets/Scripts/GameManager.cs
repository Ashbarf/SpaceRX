using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Text gameOver;
    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore ()
    {
        score += 10;
        scoreText.text = "Score: " + score;

        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake ()
    {
        inst = this;
    }

	private void Update () 
    {
        gameOver.text = "Your score is: " + score;
    }
}