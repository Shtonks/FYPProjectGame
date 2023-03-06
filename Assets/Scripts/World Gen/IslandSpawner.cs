using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    public int numberShopsToSpawn = 20;
    public List<GameObject> multiSpawnPool;
    public List<GameObject> singleSpawnPool;
    public GameObject quad;
    public GameObject shop;
    public GameObject enemy;
    public int enemiesInWorldCount = 50;
    public int lowerEnemyGroupSize = 2;
    public int upperEnemyGroupSize = 6;


    void Start()
    {
        spawnSingleIslands();
        spawnShops();
    }

    public void spawnSingleIslands()
    {
        destroyIslands();

        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < singleSpawnPool.Count; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(singleSpawnPool[i], pos, singleSpawnPool[i].transform.rotation);
        }
    }

    public void spawnShops()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberShopsToSpawn; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(shop, pos, shop.transform.rotation);
        }
    }

    public void spawnEnemies()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        int totalEnemiesInWorld = 0;
        while (totalEnemiesInWorld < enemiesInWorldCount)
        {
            int groupSize = Random.Range(lowerEnemyGroupSize, upperEnemyGroupSize);

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            
            // Creates first enemy
            Instantiate(enemy, pos, enemy.transform.rotation);

            for (int i = 0; i < groupSize; i++)
            {
                
                PreventSpawnOverlap(pos, )

                Instantiate(enemy, pos, enemy.transform.rotation);
                pos = newPos;
            }

        }


    }

    // This determines how close enemies will spawn to each other
    private Vector2 GetRandomSpawnPos(Vector2 startPos)
    {
        return startPos + GetRandomDir() * Random.Range(4f, 8f);
    }

    // Generate random normalized direction
    private static Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    public bool PreventSpawnOverlap(Vector2 pos, int radius) {
        // If 0, no collisions
        if(Physics2D.OverlapCircleAll(pos, radius).Length == 0) {
            return true;
        }
        return false;
    }

    // public void spawnIslands()
    // {
    //     destroyIslands();

    //     int randNum = 0;
    //     GameObject toSpawn;
    //     MeshCollider c = quad.GetComponent<MeshCollider>();

    //     float screenX, screenY;
    //     Vector2 pos;

    //     for (int i = 0; i < numberToSpawn; i++)
    //     {
    //         randNum = Random.Range(0, multiSpawnPool.Count);
    //         toSpawn = multiSpawnPool[randNum];

    //         screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
    //         screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
    //         pos = new Vector2(screenX, screenY);

    //         Instantiate(toSpawn, pos, toSpawn.transform.rotation);
    //     }
    // }

    private void destroyIslands()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}
