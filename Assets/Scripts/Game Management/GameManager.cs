using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int startHealth = 8;
    public static int maxHealth = 8;
    public GameObject ship;
    private IslandSpawner islandSpawner;
    private EnemySpawner enemySpawner;
    public GameOver gameOver;

    public QuestTracker questTracker;

    public List<Item> allItems;

    public static GameManager gameManager { get; private set; }
    public UnitHealth Health = new UnitHealth(startHealth, maxHealth);
    private bool playerDead;

    public static string menuOpen;

    void Awake()
    {
        // This is essentially ensuring that this is a singleton class
        if(gameManager != null && gameManager != this) {
            Destroy(this);
        }
        else {
            gameManager = this;
        }

        playerDead = false;
        menuOpen = "";
        islandSpawner = GetComponentInChildren<IslandSpawner>();
        enemySpawner = GetComponentInChildren<EnemySpawner>();
    }

    private void Start() {
        //islandSpawner.SpawnAll();
        //enemySpawner.SpawnEnemies();
    }

    public void GameOverScreen(string typeOfEndState, Faction fact) {
        Debug.Log("You died");
        playerDead = true;
        GameManager.menuOpen = "GameOver";
        gameOver.Display(typeOfEndState, fact);
    }

    private void Update() {
        // Stops ship moving
        if(playerDead) {
            ship.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ship.GetComponent<Rigidbody2D>().angularVelocity = 0;
            ship.GetComponent<TopDownShipController>().setCanMove(false);
        }
    }

    public void SpawnRepoShip(Vector2 playerPos) {
        enemySpawner.SpawnRepoShip(playerPos);
    }
}
