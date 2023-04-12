using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnCircle;
    public GameObject enemy;
    public GameObject repoShip;
    public int numEnemiesToSpawn = 10;
    public int lowerEnemyGroupSize = 2;
    public int upperEnemyGroupSize = 6;
    public int newEnemySpawnRetryLimit = 50;
    public int clusterSpawnAttemptRetryLimit = 10;
    private int effectedLayers;
    private int totalEnemiesInWorld;

    public void SpawnEnemies()
    {
        Collider2D c = spawnCircle.GetComponent<CircleCollider2D>();
        effectedLayers = LayerMask.GetMask("Land");


        float colRadius = enemy.transform.localScale.x * enemy.GetComponent<CircleCollider2D>().radius * 1.5f;
        Vector2 pos;

        int newSpawnAttempt = 0;
        int totalEnemiesInWorld = 0;
        while (totalEnemiesInWorld < numEnemiesToSpawn)
        {
            int groupSize = Random.Range(lowerEnemyGroupSize, upperEnemyGroupSize);

            float randRadLength = Random.Range(50f, c.bounds.max.x);
            pos = Vector2.zero + GetRandomDir() * randRadLength;

            // Collision radius is calced: scaleOfObj * colliderRadius * offset

            if(Physics2D.OverlapCircleAll(pos, colRadius, effectedLayers).Length == 0) {
                // Creates first enemy
                Instantiate(enemy, pos, enemy.transform.rotation);
                totalEnemiesInWorld++;
                SpawnEnemyCluster(groupSize, pos);
            } else {
                newSpawnAttempt++;
            }
            if(newSpawnAttempt > newEnemySpawnRetryLimit){
                Debug.Log("Hit new Enemy limit");
                return;
            }
        }
    }

    public void SpawnEnemyCluster(int groupSize, Vector2 startPos) {
        Vector2 pos = startPos;
        int i = 0;
        int clusterSpawnAttempt = 0;
        while(i < groupSize)
        {
            Vector2 newPos = GetRandomSpawnPos(pos);
            // Collision radius is calced: scaleOfObj * colliderRadius * offset
            float colRadius = enemy.transform.localScale.x * enemy.GetComponent<CircleCollider2D>().radius * 1.5f;

            // If 0, no collisions
            // int size = Physics2D.OverlapCircleAll(newPos, colRadius).Length;
            if(Physics2D.OverlapCircleAll(pos, colRadius, effectedLayers).Length == 0) {
                Instantiate(enemy, newPos, enemy.transform.rotation);
                pos = newPos;
                i++;
            } else {
                clusterSpawnAttempt++;
            }
            if(clusterSpawnAttempt > clusterSpawnAttemptRetryLimit){
                Debug.Log("Hit cluster spawn limit");
                return;
            }
        }
    }

    // This determines how close enemies will spawn to each other
    private Vector2 GetRandomSpawnPos(Vector2 startPos)
    {
        float rand = Random.Range(4f, 8f);
        //Debug.Log("rand: " + rand);
        return startPos + GetRandomDir() * rand;
    }

    // Generate random normalized direction
    private static Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    public void SpawnRepoShip(Vector2 playerPos) {
        playerPos = new Vector2(playerPos.x, playerPos.y - 40);
        Instantiate(repoShip, playerPos, repoShip.transform.rotation);
        Debug.Log("Repo ship spawned");
    }
}
