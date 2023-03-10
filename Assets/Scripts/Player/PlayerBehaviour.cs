using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public List<Quest> quests;
    
    public int speed;
    public int fuelLvl;
    public int shards;

    public PlayerBehaviour() {
        speed = 0;
        fuelLvl = 10;
        shards = 70;
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     TakeDmg(2);
        // }
        // if(Input.GetKeyDown(KeyCode.LeftShift)) {
        //     Heal(1);
        // }        
    }

    public void QuestComplete(Quest q) {
        shards += q.shardReward;
        Debug.Log(q.title + " completed!!");
        q.isActive = false;
    }

    public void TakeDmg(int dmg) {
        GameManager.gameManager.Health.dmgUnit(dmg);
        
    }

    public void Heal(int heal) {
        GameManager.gameManager.Health.healUnit(heal);
    }

    public int GetHealth() {
        return GameManager.gameManager.Health.Health;
    }
}
