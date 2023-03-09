using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestGiver : MonoBehaviour
{
    //AllQuests allQuests;
    public Quest quest;
    public PlayerBehaviour player;
    public QuestMaker questMaker = new QuestMaker();

    public GameObject questWindow;
    public TMP_Text txtTitle;
    public TMP_Text txtDesc;
    public TMP_Text txtShardReward;
    //public TMP_Text txtFactionReward;

    private void Start() {
        //allQuests = new AllQuests();
    }

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
        quest.isActive = true;
        player.quests.Add(quest);
    }

}
