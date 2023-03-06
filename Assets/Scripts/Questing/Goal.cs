using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public Goal(GoalType goalType, int requiredAmount) {
        this.goalType = goalType;
        this.requiredAmount = requiredAmount;
        this.currentAmount = 0;
    }

    public bool CheckComplete() {
        return (currentAmount >= requiredAmount);
    }

    public void LocationDiscovered() {
        if(goalType == GoalType.Explore)
            currentAmount++;
        // Check player pos vs POI pos
    }

    public void MaterialDelivered() {
        if(goalType == GoalType.Deliver)
            currentAmount++;
        // Check location reached and 
    }
    
}

// This could be expanded out to use inheritance instead, if system grows any bigger
public enum GoalType {
    Deliver,
    Explore
}