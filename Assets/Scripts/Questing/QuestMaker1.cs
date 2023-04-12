using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class QuestMaker1
{
    List<Quest> testQuests;

    public QuestMaker1() {
        testQuests = new List<Quest>();
    }


    public void GenQuest(DeliveryGoal g) {
        Item randItem = g.itemWanted;
        List<Faction> randFacts = g.factions;

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

        testQuests.Add(new Quest(title, "Lorem Ipsum", shardReward, factionReward, g));
    }

    public List<Quest> Output() {
        DeliveryGoal dg;

        // Jura fact, all items
        for (int i = 0; i < 6; i++)
        {
            dg = new DeliveryGoal(new List<Faction>{Jura.Instance}, GameManager.gameManager.allItems[i]);
            GenQuest(dg);
        }

        // Naar, 
        dg = new DeliveryGoal(new List<Faction>{Nardvaal.Instance}, GameManager.gameManager.allItems[0]);
        GenQuest(dg);

        dg = new DeliveryGoal(new List<Faction>{Welkan.Instance}, GameManager.gameManager.allItems[0]);
        GenQuest(dg);

        // Jura and Welk fact, all items
        for (int i = 0; i < 6; i++)
        {
            dg = new DeliveryGoal(new List<Faction>{Jura.Instance, Welkan.Instance}, GameManager.gameManager.allItems[i]);
            GenQuest(dg);
        }

        // Naar and Welk
        dg = new DeliveryGoal(new List<Faction>{Nardvaal.Instance, Welkan.Instance}, GameManager.gameManager.allItems[0]);
        GenQuest(dg);

        // Naar and Jura
        dg = new DeliveryGoal(new List<Faction>{Jura.Instance, Nardvaal.Instance}, GameManager.gameManager.allItems[0]);
        GenQuest(dg);

        // All together, all items
        for (int i = 0; i < 6; i++)
        {
            dg = new DeliveryGoal(new List<Faction>{Jura.Instance, Welkan.Instance, Nardvaal.Instance}, GameManager.gameManager.allItems[i]);
            GenQuest(dg);
        }

        return testQuests;
    }
}
