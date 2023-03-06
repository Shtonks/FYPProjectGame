using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string desc;
    public int shardReward;
    // public int factionReward; // Type may need to be changed 
    
    public Goal questGoal;

    public Quest (string title, string desc, int shardReward, GoalType goalType, int requiredAmount) {
        isActive = false;
        this.title = title;
        this.desc = desc;
        this.shardReward = shardReward;
        questGoal = new Goal(goalType, requiredAmount);
    }
}
