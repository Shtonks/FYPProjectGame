using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject quad;
    public GameObject enemy;
    public int enemiesInWorldCount = 10;
    public int lowerEnemyGroupSize = 2;
    public int upperEnemyGroupSize = 6;

    void Start()
    {
        spawnEnemies();
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

            //Debug.Log("New initial enemy created");
            //Debug.Log("Initial Pos: " + pos);

            int i = 0;
            int attempt = 0;
            while(i < groupSize)
            {
                Vector2 newPos = GetRandomSpawnPos(pos);
                float colRadius = enemy.GetComponent<CircleCollider2D>().radius * 1.5f;
                //Debug.Log("New pos: " + newPos);           

                // If 0, no collisions
                int size = Physics2D.OverlapCircleAll(newPos, colRadius).Length;
                
                if(Physics2D.OverlapCircleAll(newPos, colRadius).Length == 0) {
                    Instantiate(enemy, newPos, enemy.transform.rotation);
                    pos = newPos;
                    i++;
                    //Debug.Log("Enemy: " + i);
                }
                attempt++;
                if(attempt > 10){
                    Debug.Log("Enemy spawn retry limit hit!!");
                    i++;
                }
            }
            totalEnemiesInWorld += groupSize;
        }
        // Debug.Log("total en:" + totalEnemiesInWorld);
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
}
