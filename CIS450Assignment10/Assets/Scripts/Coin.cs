/*
 * Gerard Lamoureux
 * Coin
 * Assignment 10
 * Handles Coin Logic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime = 6f;
    private void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!GameController.Instance.gameOver)
            {
                Deactivate();
                GameController.Instance.AddCoin();
            }
        }
    }

    private void Deactivate()
    {
        if (!GameController.Instance.gameOver)
            gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
