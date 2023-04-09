using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Quest> quests;
    public int numOfQuests;

    private void Start() {
        quests = new List<Quest>();
        QuestMaker questMaker = new QuestMaker();
        for (int i = 0; i <= numOfQuests; i++)
        {
            quests.Add(questMaker.GenQuest());
            //Debug.Log("Details:" + quests[i].title);
        }
    }
}
