using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class QuestMaker
{
    public Quest GenQuest() {
        Item randItem = RandomItem();
        Faction randFact = RandomFaction();

        string title = randFact.getName() + " requires " + randItem.name;
        // Random reward. Reward size decision could be improved
        int shardReward = UnityEngine.Random.Range(50, 200);
        int factionReward = 3;

        Goal goal = new DeliveryGoal(randFact, randItem);

        return (new Quest(title, "Lorem Ipsum", shardReward, factionReward, goal));

        //TEST
        // Goal testGoal = new DeliveryGoal(Welkan.Instance, Item.Wood);
        // return (new Quest("Testing welk and wood", "Lorem Ipsum", 42, factionReward, testGoal));

    }

    private Item RandomItem() { 
        int randItemNum = UnityEngine.Random.Range(0, GameManager.gameManager.allItems.Count);
        return GameManager.gameManager.allItems[randItemNum];
    }

    private Faction RandomFaction() {
        Faction randFact;
        int randFactNum = UnityEngine.Random.Range(0, 3);
        // Debug.Log("Rnad num" + randFactNum);
        switch(randFactNum) {
            default:
            case 0:
                randFact = Jura.Instance;
                break;
            case 1:
                randFact = Nardvaal.Instance;
                break;
            case 2:
                randFact = Welkan.Instance;
                break;
        }
        return randFact;
    }
}
