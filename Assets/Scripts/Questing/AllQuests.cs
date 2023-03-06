using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllQuests
{
    public List<Quest> listOfAllQuests;

    public AllQuests() {
        listOfAllQuests = new List<Quest>();
        listOfAllQuests.Add(new Quest("Deliver materials to location X", 
                                "Give some nice lore here, idk", 
                                50, 
                                GoalType.Deliver, 
                                1));
        listOfAllQuests.Add(new Quest("Find a stable route to location X", 
                                "Give some nice lore here, idk", 
                                123, 
                                GoalType.Explore, 
                                1));
        listOfAllQuests.Add(new Quest("Find the Welkans 3 major outposts", 
                                "Give some nice lore here, idk", 
                                300, 
                                GoalType.Deliver, 
                                1));
        
    }
}
