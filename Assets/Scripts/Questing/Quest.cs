using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public Item item;
    public Faction deliveryFact;
    public string title;
    public string desc;
    public int shardReward;
    public int factionReward; // Type may need to be changed 
    
    public Goal questGoal;

    // Contract Quest specifically
    public Quest (Item item, Faction fact, string desc, int shardReward, int factionReward, int requiredAmount) {
        this.item = item;
        deliveryFact = fact;
        this.title = fact.getName() + " requires " + item.ToString() + "TETSTTTTTT";
        this.desc = desc;
        this.shardReward = shardReward;
        this.factionReward = factionReward;
        questGoal = new Goal( requiredAmount);
    }
}
