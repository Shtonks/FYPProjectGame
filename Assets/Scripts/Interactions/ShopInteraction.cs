using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteraction : GenericShopInteraction
{
    public Quest quest;
    public QuestMaker questMaker = new QuestMaker();
    public QuestTracker questTracker;
    public Button contractSelect;

    // Quest window elements
    public GameObject questWindow;
    public TMP_Text txtTitle;
    public TMP_Text txtDesc;
    public TMP_Text txtShardReward;
    //public TMP_Text txtFactionReward;


    public void OpenQuestWindow() {
        quest = questMaker.GenQuest();
        questWindow.SetActive(true);
        txtTitle.text = quest.title.ToString();
        txtDesc.text = quest.desc.ToString();
        txtShardReward.text = quest.shardReward.ToString();
        //txtFactionReward.text = quest.factionReward.ToString();
    }

    public void AcceptQuest() {
        questWindow.SetActive(false);
        // Means can only take on 1 quest for now. not ideal
        contractSelect.interactable = false;
        pb.quests.Add(quest);
        questTracker.CreateQuestTracker(quest.title, quest.desc, 1);
    }

    public void AbandonQuest() {
        // Shards penalty of -50% what you wouls have got
        pb.shards -= quest.shardReward / 2;
        contractSelect.interactable = true;
        pb.quests.Remove(quest);
        questTracker.DeactivateTracker();
    }
}
