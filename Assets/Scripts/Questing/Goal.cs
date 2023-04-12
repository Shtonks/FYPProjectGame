using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal{
    public List<Faction> factions;
}

[System.Serializable]
public class DeliveryGoal : Goal
{
    public Item itemWanted;

    public DeliveryGoal(List<Faction> factions, Item item) {
        this.factions = factions;
        itemWanted = item;
    }

    public bool IsFactionFound(Faction f) {
        foreach (Faction fact in factions)
        {
            Debug.Log("Comparing: " + fact.getName() + " and " + f.getName());
            if(fact == f) return true;
        }
        return false;
    }

    public void DisplayAllFacts() {
        foreach (Faction f in factions) {
            Debug.Log("Faction in goal: " + f.getName());
        }
    }
}