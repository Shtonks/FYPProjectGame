using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteraction : GenericShopInteraction
{
    public List<Quest> quests;
    public int numOfQuests;
    private int currentVisibleQuest;
    public Button contractSelect;
    public Button contractAbandon;

    // Quest window elements
    public GameObject questWindow;
    public TMP_Text txtTitle;
    //public TMP_Text txtDesc;
    public TMP_Text txtShardReward;
    public TMP_Text txtFactionReward;

    public QuestTracker questTracker;

    private void Start() {
        contractAbandon.interactable = false;
        numOfQuests = 2;
        quests = new List<Quest>();
        QuestMaker questMaker = new QuestMaker();
        Debug.Log("Made it here");
        for (int i = 0; i <= numOfQuests; i++)
        {
            Debug.Log("Quest: " + i);
            quests.Add(questMaker.GenQuest());
            Debug.Log("Details:" + quests[i].title);
        }
        currentVisibleQuest = 0;
    }

    private void OnDisable() {
        questWindow.SetActive(false);
        //Debug.Log("DEACTIVATING");
    }

    public void CycleQuestWindow() {
        questWindow.SetActive(true);
        txtTitle.text = quests[currentVisibleQuest].title.ToString();
        //txtDesc.text = quest.desc.ToString();
        txtShardReward.text = quests[currentVisibleQuest].shardReward.ToString();
        txtFactionReward.text = quests[currentVisibleQuest].factionReward.ToString();
        currentVisibleQuest++;
        if(currentVisibleQuest >= numOfQuests) currentVisibleQuest = 0;
    }

    public void AcceptQuest() {
        questWindow.SetActive(false);
        pb.quests.Add(quests[currentVisibleQuest]);
        questTracker.CreateQuestTracker(quests[currentVisibleQuest].title, quests[currentVisibleQuest].desc, 1);
        contractSelect.interactable = false;
        contractAbandon.interactable = true;
    }

    public void AbandonQuest() {
        // Shards penalty of -50% what you would have got
        pb.shards -= quests[currentVisibleQuest].shardReward / 2;
        pb.quests.Remove(quests[currentVisibleQuest]);
        questTracker.DeactivateTracker();
        contractSelect.interactable = true;
        contractAbandon.interactable = false;
    }
}
