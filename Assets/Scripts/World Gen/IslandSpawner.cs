using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    public GameObject mainSpawnCircle;
    public GameObject factionSpawnCircle;

    public List<GameObject> factionSpawnPool;
    
    public float POIColOffset = 1.5f;
    public List<GameObject> POISpawnPool;

    public GameObject shop;
    public int numShopsToSpawn;
    public float shopCollOffset;

    private int effectedLayers;
    CircleCollider2D c;

    public void SpawnAll() {
        c = mainSpawnCircle.GetComponent<CircleCollider2D>();
        effectedLayers = LayerMask.GetMask("Land");
        SpawnFactions();
        SpawnIslands();
        SpawnShops();
    }

    public void SpawnFactions() {
        Collider2D spawnCir = factionSpawnCircle.GetComponent<CircleCollider2D>();
        // Shuffle factions
        System.Random rand = new System.Random();
        factionSpawnPool = factionSpawnPool.OrderBy(_ => rand.Next()).ToList();

        Vector2[] spawnCentres = {new Vector2(170f, 170f),
                                    new Vector2(-170f, 170f),
                                    new Vector2(170f, -170f),
                                    new Vector2(-170f, -170f)};
                                    
        for (int i = 0; i < factionSpawnPool.Count; i++)
        {   
            // Get random loc to spawn inside set area
            spawnCir.transform.position = spawnCentres[i];
            float randRadLength = Random.Range(0f, spawnCir.bounds.max.x);
            Vector2 pos = spawnCentres[i] + GetRandomDir() * randRadLength;
            Instantiate(factionSpawnPool[i], pos, factionSpawnPool[i].transform.rotation);
            //factionSpawnPool[i].transform.position = pos;
            //TEMP: Just shows sizes of spawn region for facts
            //Instantiate(spawnCir, spawnCir.transform.position, spawnCir.transform.rotation);
        }
    }

    public void SpawnIslands() {
        // Shuffle island order
        System.Random rand = new System.Random();
        POISpawnPool = POISpawnPool.OrderBy(_ => rand.Next()).ToList();

        // Set of backup, preset spawn points
        Vector2[] backupPOISpawnPoints = {new Vector2(71, 328),
                                            new Vector2(-14, 170),
                                            new Vector2(-334, 40),
                                            new Vector2(77, -30),
                                            new Vector2(280, 29),
                                            new Vector2(319, -92),
                                            new Vector2(84, -330),
                                            new Vector2(-50, -246)};

        foreach (GameObject island in POISpawnPool){
            // Collision radius is calced: scaleOfObj * colliderRadius * offset
            float colRadius = island.transform.localScale.x * island.GetComponent<CircleCollider2D>().radius * POIColOffset;
            bool result = SpawnLoc(1, island, 50, colRadius);
            
            if(!result){
                for (int i = 0; i < backupPOISpawnPoints.Count(); i++)
                {
                    if(Physics2D.OverlapCircleAll(backupPOISpawnPoints[i], colRadius, effectedLayers).Length == 0) {
                        island.transform.position = backupPOISpawnPoints[i];
                        break;
                    }
                }
            }
        }
    }

    private bool SpawnLoc(int numToSpawn, GameObject objToSpawn, int spawnRetryLimit, float colRadius) {
        int attempt = 0;
        for (int i = 0; i < numToSpawn; i++)
        {
            // Circle spawning
            // Get spawn pos by picking a random dir and then picking a random length of circle rad and spawning there 
            float randRadLength = Random.Range(50f, c.bounds.max.x);
            Vector2 pos = Vector2.zero + GetRandomDir() * randRadLength;

            if(Physics2D.OverlapCircleAll(pos, colRadius, effectedLayers).Length == 0) {
                Instantiate(objToSpawn, pos, objToSpawn.transform.rotation);
            } else {
                attempt++;
                i--;
            }
            if(attempt > spawnRetryLimit){
                return false;
            }
        }
        return true;
    }


    public void SpawnShops()
    {
        // Collision radius is calced: scaleOfObj * colliderRadius * offset
        float colRadius = shop.transform.localScale.x * shop.GetComponent<CircleCollider2D>().radius * POIColOffset;

        SpawnLoc(numShopsToSpawn, shop, 50, colRadius);
    }

    // Generate random normalized direction
    private static Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
