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
    private int effectedLayers;

    void Start()
    {
        effectedLayers = LayerMask.GetMask("Land");
        //spawnSingleIslands();
        spawnShops();
        //spawnTrees();
    }

    // Disabled for now
    // Need to test this when big/varying sized isalnds are added for the .radius * 1.5. May be an issue
    public void spawnSingleIslands()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        int i = 0;
        int attempt = 0;
        while (i < singleSpawnPool.Count)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            // All islands drawn in rough circular shapes, so can use this
            float colRadius = singleSpawnPool[i].GetComponent<CircleCollider2D>().radius * 1.5f;

            // If 0, no collisions
            if(Physics2D.OverlapCircleAll(pos, colRadius).Length == 0) {
                singleSpawnPool[i].transform.position = pos;
            } else {
                attempt++;
                i--;
            }
            if(attempt > 10){
                Debug.Log("Retry limit hit");
            }
        }
    }

    public void spawnShops()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;
        int attempt = 0;
        float colRadius = shop.GetComponent<CircleCollider2D>().radius * 1.5f;
        Debug.Log("Shop col rad: " + shop.GetComponent<CircleCollider2D>().radius);


        for (int i = 0; i < numberShopsToSpawn; i++)
        {
            Debug.Log("Shop NUm:" + i);
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Debug.Log("Coords:" + pos);

            Debug.Log("Num colls:" + Physics2D.OverlapCircleAll(pos, colRadius, effectedLayers).Length);

            if(Physics2D.OverlapCircleAll(pos, colRadius, effectedLayers).Length == 0) {
                Debug.Log("Made island");
                Instantiate(shop, pos, shop.transform.rotation);
            } else {
                Debug.Log("Retry");
                attempt++;
                i--;
            }
            if(attempt > 10){
                Debug.Log("Retry limit hit");
            }
        }
    }

    public void spawnTrees()
    {
        Vector2 pos;

        int totalTreesInWorld = 0;
        while (totalTreesInWorld < numberShopsToSpawn)
        {
            int groupSize = numberShopsToSpawn;
            pos = GetRandomSpawnPos();

            // Creates first tree
            Instantiate(shop, pos, shop.transform.rotation);

            int i = 0;
            int attempt = 0;
            while (i < groupSize)
            {
            Debug.Log("New spawn:" + i);
                Vector2 newPos = GetRandomSpawnPos();
                float colRadius = shop.GetComponent<CircleCollider2D>().radius * 1.5f;

                // If 1, no collisions
                int size = Physics2D.OverlapCircleAll(newPos, colRadius).Length;
                Debug.Log("Num colls:" + size);

                if (Physics2D.OverlapCircleAll(newPos, colRadius).Length == 0)
                {
                    Debug.Log("Made");
                    Instantiate(shop, newPos, shop.transform.rotation);
                    pos = newPos;
                    i++;
                } else if (Physics2D.OverlapCircleAll(newPos, colRadius).Length == 0) {
                    Debug.Log("Attempt inc:" + attempt);
                    attempt++;
                }
                if (attempt > 20)
                {
                    Debug.Log("Tree spawn retry limit hit!!");
                    i++;
                }
            }
            totalTreesInWorld += groupSize;
        }
    }

// Gets new spawn location within bounds
    private Vector2 GetRandomSpawnPos()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        return new Vector2(screenX, screenY);
    }
    
}
