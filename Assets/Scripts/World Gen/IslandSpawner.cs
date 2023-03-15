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

    void Start()
    {
        spawnSingleIslands();
        spawnShops();
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
                i++;
            }
            attempt++;
            if(attempt > 100){
                i++;
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


        for (int i = 0; i < numberShopsToSpawn; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            if(Physics2D.OverlapCircleAll(pos, colRadius).Length == 0) {
                Instantiate(shop, pos, shop.transform.rotation);
            }
            attempt++;
            if(attempt > 100){
                i++;
                Debug.Log("Spawn shop attempt limit hit");
            }
        }
    }

    
}
