using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal{
    public Faction faction;
}

public class DeliveryGoal : Goal
{
    public Item itemWanted;

    public DeliveryGoal(Faction faction, Item item) {
        this.faction = faction;
        itemWanted = item;
    }
}

// [System.Serializable]
// public class Goal
// {
//     public int requiredAmount;
//     public int currentAmount;

//     public Goal(int requiredAmount) {
//         this.requiredAmount = requiredAmount;
//         this.currentAmount = 0;
//     }

//     public virtual bool CheckComplete() {
//         return (currentAmount >= requiredAmount);
//     }

//     public void Success() {
//         currentAmount++;
//     }
// }

// public class DeliveryGoal : Goal
// {
//     public DeliveryGoal(int requiredAmount) : base(requiredAmount)
//     {
//     }
// }