using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class QuestMaker
{
    public Quest GenQuest() {
        Item randItem = RandomItem();
        List<Faction> randFacts = RandomFactions();

        string title = "";

        foreach (Faction f in randFacts) {
            title += f.getName() +" or ";
        }
        title = title.Substring(0, title.Length - 3);
        title += "requires " + randItem.name;

        int shardReward = 0;
        int factionReward = 0;

        // Random reward. Reward size decision could be improved
        switch(randFacts.Count) {
            case 1:
                shardReward = UnityEngine.Random.Range(50, 100);
                factionReward =  2;
                break;
            case 2:
                shardReward = UnityEngine.Random.Range(100, 150);
                factionReward =  5;
                break;
            case 3:
                shardReward = UnityEngine.Random.Range(150, 220);
                factionReward =  8;
                break;  
        }

        Debug.Log("All quest deets = title: " + title + " shardreward: " + shardReward + " factionereard: "+ factionReward);

        Goal goal = new DeliveryGoal(randFacts, randItem);

        return (new Quest(title, "Lorem Ipsum", shardReward, factionReward, goal));

        //TEST
        // Goal testGoal = new DeliveryGoal(Welkan.Instance, Item.Wood);
        // return (new Quest("Testing welk and wood", "Lorem Ipsum", 42, factionReward, testGoal));

    }

    private Item RandomItem() { 
        int randItemNum = UnityEngine.Random.Range(0, GameManager.gameManager.allItems.Count);
        return GameManager.gameManager.allItems[randItemNum];
    }

    private List<Faction> RandomFactions() {
        List<Faction> facts = new List<Faction>();
        int randFactNum = UnityEngine.Random.Range(0, 7);
        Debug.Log("Rnad num" + randFactNum);
        switch(randFactNum) {
            case 0:
                facts.Add(Jura.Instance);
                break;
            case 1:
                facts.Add(Nardvaal.Instance);
                break;
            case 2:
                facts.Add(Welkan.Instance);
                break;
            case 3:
                facts.Add(Jura.Instance);
                facts.Add(Nardvaal.Instance);
                break;
            case 4:
                facts.Add(Nardvaal.Instance);
                facts.Add(Welkan.Instance);
                break;
            case 5:
                facts.Add(Jura.Instance);
                facts.Add(Welkan.Instance);
                break;
            case 6:
                facts.Add(Jura.Instance);
                facts.Add(Nardvaal.Instance);
                facts.Add(Welkan.Instance);
                break;
        }
        return facts;
    }
}
