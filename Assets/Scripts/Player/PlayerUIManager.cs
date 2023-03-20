using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerBehaviour pb;
    
    public TMP_Text txtSpeed;
    public TMP_Text txtHealth;
    public TMP_Text txtFuel;
    public TMP_Text txtShards;

    private int lastSpeed;
    public int lastHealth;
    private int lastFuelLvl;
    private int lastShards;

    // public int health;

    public List<GameObject> healthStatusBar;
    public int maxHealth;

    void Start()
    {
        // health = pb.GetHealth();
        maxHealth = GameManager.gameManager.Health.MaxHealth;

        txtSpeed.text = "0" + pb.speed.ToString();
        txtFuel.text = pb.fuelLvl.ToString();
        txtShards.text = pb.shards.ToString();
    }

    void Update()
    {
        //TO DO: I'll have to deal with negative speed soon to
        if(lastSpeed != pb.speed) {
            if(pb.speed < 10) {
                txtSpeed.text = "0" + pb.speed.ToString();
            }else {
                txtSpeed.text = pb.speed.ToString();
            }
        }

        if (lastHealth != pb.GetHealth()) {
            SetHealthStatusBar(pb.GetHealth());
            lastHealth = pb.GetHealth();
        }

        if (lastFuelLvl != pb.fuelLvl) {
            txtFuel.text = pb.fuelLvl.ToString();
        }

        if (lastShards != pb.shards) {
            txtShards.text = pb.shards.ToString();
        }
    }

    private void SetHealthStatusBar(int currentHealth) {
        for (int i = 0; i < maxHealth; i++)
        {
            if(i < currentHealth) {
                healthStatusBar[i].SetActive(true);
            } else {
                healthStatusBar[i].SetActive(false);
            }
        }
    }
}
