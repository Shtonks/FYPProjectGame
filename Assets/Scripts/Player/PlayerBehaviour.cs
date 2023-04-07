using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public List<Quest> quests;
    public Inventory inventory;

    public PlayerUIManager playerUIManager;

    
    public int speed;
    public int fuelLvl;
    public int shards;

    public float maxShipSpeed;
    public int maxFuelLvl;
    public float accelFactor;
    public float shieldCountdownInterval;
    public float shieldRechargeInterval;


    private void Start() {
        speed = 0;
        fuelLvl = 10;
        shards = 70;
        maxShipSpeed = 10.0f;
        maxFuelLvl = 10;
        accelFactor = 5.0f;
        shieldCountdownInterval = 2f;
        shieldRechargeInterval = 4f;
        inventory = new Inventory();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            DestroyItem(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            DestroyItem(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            DestroyItem(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            DestroyItem(4);
        }
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

    public void QuestComplete(Quest quest) {
        Debug.Log(quest.title + " completed!!");
        shards += quest.shardReward;
        quests.Remove(quest);
        //IncreaseFactioRep(quest.questGoal.faction, quest.factionReward);
        IncreaseFactioRep(Nardvaal.Instance, 15);
    }

    public void IncreaseFactioRep(Faction fact, int repInc) {
        fact.increaseRep(repInc);
        playerUIManager.SetFactionRep(fact, fact.getRep());
    }

    public void AddItem(Item newItem) {
        int key = inventory.AddItem(newItem);
        Debug.Log("Key: "+ key);
        if(key > -1) {
            playerUIManager.UpdateItemSlotIcon(key, newItem);
        }
    }

    public void DestroyItem(int key) {
        if(inventory.inventoryItems.Count >= key && inventory.inventoryItems[key].name != ""){
            inventory.DestroyItem(key);
            playerUIManager.UpdateItemSlotIcon(key, inventory.blankItem);
        }
    }
}
