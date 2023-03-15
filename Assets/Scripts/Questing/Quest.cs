using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string desc;
    public int shardReward;
    public int factionReward;
    
    public Goal questGoal;

    // Contract Quest specifically
    public Quest (string title, string desc, int shardReward, int factionReward, Goal goal) {
        this.title = title;
        this.desc = desc;
        this.shardReward = shardReward;
        this.factionReward = factionReward;
        questGoal = goal;
    }
}
