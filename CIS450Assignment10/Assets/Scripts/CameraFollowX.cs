/*
 * Gerard Lamoureux
 * CameraFollowX
 * Assignment 10
 * Camera follows the x position of the player only
 */

using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform player;
    public float yOffset;

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x + 7, yOffset, transform.position.z);
        transform.position = newPosition;
    }
}