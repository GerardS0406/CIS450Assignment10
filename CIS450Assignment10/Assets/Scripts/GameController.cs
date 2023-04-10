/*
 * Gerard Lamoureux
 * GameController
 * Assignment 10
 * Handles overall game and end logic
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public GameObject instructionsText;

    public GameObject gameOverObject;

    public TextMeshProUGUI coinText;

    public bool gameOver = false;

    private bool win = false;

    public int coinTotal = 0;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Destroy(instructionsText);
            Time.timeScale = 1;
        }

        coinText.text = "Coins: " + coinTotal + "/20";
    }

    public void AddCoin()
    {
        coinTotal += 1;
        if (coinTotal >= 20)
            EndGame(true);
    }

    public void EndGame(bool win)
    {
        gameOver = true;
        gameOverObject.SetActive(true);
        if(win)
        {
            gameOverObject.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over!\nYou Win!";
        }
        else
        {
            gameOverObject.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over!\nYou Lose!";
        }
    }

    public void ReplayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
