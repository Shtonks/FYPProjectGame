using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int startHealth = 8;
    public static int maxHealth = 8;

    public static GameManager gameManager { get; private set; }
    public UnitHealth Health = new UnitHealth(startHealth, maxHealth);

    void Awake()
    {
        // This is essentially ensuring that this is a singleton class
        if(gameManager != null && gameManager != this) {
            Destroy(this);
        }
        else {
            gameManager = this;
        }
    }
}
