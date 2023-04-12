using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Quest> quests;
    public int numOfQuests;
    private QuestMaker questMaker;

    private QuestMaker1 test;

    private void Start() {
        quests = new List<Quest>();
        questMaker = new QuestMaker();
        GenNewQuests();

        // TEST CODE
        test = new QuestMaker1();
        quests = test.Output();
        Debug.Log("Num quests should be 22: " + quests.Count);
    }

    public void GenNewQuests() {
        // ACTUAL CODE

        // quests.Clear();
        // for (int i = 0; i < numOfQuests; i++)
        // {
        //     quests.Add(questMaker.GenQuest());
        //     //Debug.Log("Details:" + quests[i].title);
        // }
        
    }
}
