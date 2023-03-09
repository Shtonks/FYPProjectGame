using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestMaker
{
    private List<string> material = new List<string>() {
        "Food",
        "Wood",
        "Iron",
        "Marble",
        "Obsidian",
        "GlowOil"
    };

    public Quest GenQuest() {
        // Decide material
        string randMat = material[Random.Range(0, material.Count)];
        
        // Decide faction (and inherently, delivery location)
        Faction randFact;
        int randFactNum = Random.Range(0, 3);
        switch(randFactNum) {
            default:
            case 1:
                randFact = Jura.Instance;
                break;
            case 2:
                randFact = Nardvaal.Instance;
                break;
            case 3:
                randFact = Nardvaal.Instance;
                break;
        }

        string factName = randFact.getName();

        Debug.Log("Mat: " + randMat);
        Debug.Log("Fact: " + randFact);

        string questTitle = factName + " requires " + randMat;
        // Random reward. Reward size decision could be improved
        int shardReward = Random.Range(50, 200);

        return (new Quest(questTitle, "Lorem Ipsum", shardReward, GoalType.Deliver, 1));
    }

    // public AllQuests() {
    //     listOfAllQuests = new List<Quest>();
    //     listOfAllQuests.Add(new Quest("Deliver materials to location X", 
    //                             "Give some nice lore here, idk", 
    //                             50, 
    //                             GoalType.Deliver, 
    //                             1));
    //     listOfAllQuests.Add(new Quest("Find a stable route to location X", 
    //                             "Give some nice lore here, idk", 
    //                             123, 
    //                             GoalType.Explore, 
    //                             1));
    //     listOfAllQuests.Add(new Quest("Find the Welkans 3 major outposts", 
    //                             "Give some nice lore here, idk", 
    //                             300, 
    //                             GoalType.Deliver, 
    //                             1));
        
    // }
}
