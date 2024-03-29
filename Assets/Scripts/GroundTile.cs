﻿using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;
    [SerializeField] GameObject[] obstaclePrefab = new GameObject[3];
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject wallPrefab;

    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnWall()
    {
        // Wall Position Left & Right
        Transform spawnPointLeft = transform.GetChild(5).transform;
        Transform spawnPointRight = transform.GetChild(6).transform;

        // Spawn the wall
        Instantiate(wallPrefab, spawnPointLeft.position, Quaternion.identity, transform);
        Instantiate(wallPrefab, spawnPointRight.position, Quaternion.identity, transform);
    }

    public void SpawnCoins ()
    {
        int coinsToSpawn = 1;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}