/*
 * Gerard Lamoureux
 * PipeDetection
 * Assignment 10
 * Handles player colliding with pipe or ground
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.Instance.EndGame(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Instance.EndGame(false);
        }
    }
}
