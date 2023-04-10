/*
 * Gerard Lamoureux
 * Spawner2D
 * Assignment 10
 * Handles spawning objects from the object pool
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public float spawnRate = 1f;
    public float obstacleSpawnDistance = 10f;
    public float coinSpawnDistance = 5f;
    public float groundSpawnDistance = 10f;

    private float nextObstacleSpawnTime = 5f;
    private float nextCoinSpawnTime = 10f;
    private float nextGroundSpawnTime = 0f;

    public Transform player;

    private void Update()
    {
        if(player.position.x + obstacleSpawnDistance >= nextObstacleSpawnTime)
        {
            SpawnObstacle();
            nextObstacleSpawnTime += spawnRate;
        }

        if(player.position.x >= nextCoinSpawnTime - coinSpawnDistance)
        {
            SpawnCoin();
            nextCoinSpawnTime += spawnRate;
        }

        if(player.position.x + groundSpawnDistance >= nextGroundSpawnTime)
        {
            SpawnGround();
            SpawnCeiling();
            nextGroundSpawnTime += groundSpawnDistance;
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(nextObstacleSpawnTime, Random.Range(-2f, 2f), 0);
        ObjectPooler.Instance.SpawnFromPool("Obstacle", spawnPosition, Quaternion.identity);
    }

    private void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(nextCoinSpawnTime, Random.Range(-2f, 2f), 0);
        ObjectPooler.Instance.SpawnFromPool("Coin", spawnPosition, Quaternion.identity);
    }

    private void SpawnGround()
    {
        Vector3 spawnPosition = new Vector3(nextGroundSpawnTime, -5.5f, 0);
        ObjectPooler.Instance.SpawnFromPool("Ground", spawnPosition, Quaternion.identity);
    }

    private void SpawnCeiling()
    {
        Vector3 spawnPosition = new Vector3(nextGroundSpawnTime, 5.5f, 0);
        ObjectPooler.Instance.SpawnFromPool("Ceiling", spawnPosition, Quaternion.identity);
    }
}
