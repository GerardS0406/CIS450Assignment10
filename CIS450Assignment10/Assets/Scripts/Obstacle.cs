/*
 * Gerard Lamoureux
 * Obstacle
 * Assignment 10
 * Overall Obstacle logic for despawn
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 6f;

    private void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    private void Deactivate()
    {
        if(!GameController.Instance.gameOver)
            gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
